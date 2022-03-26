using System.Data.SqlClient;
var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
    "Initial Catalog=Northwind;" +
    "Integrated Security=True;" +
    "Connect Timeout=30;" +
    "Encrypt=False;" +
    "TrustServerCertificate=False;" +
    "ApplicationIntent=ReadWrite;" +
    "MultiSubnetFailover=False";

var conn = new SqlConnection(connectionString);
conn.Open();

var getQueryString = "SELECT * FROM [dbo].[Region]";
var setQueryString = "INSERT INTO [dbo].[Region] ([RegionID],[RegionDescription]) VALUES (6,'slask')"; 
var getQueryStringCommand = new SqlCommand(getQueryString, conn);
var setQueryStringCommand = new SqlCommand(setQueryString, conn);

var add = setQueryStringCommand.ExecuteNonQuery();

var reader = getQueryStringCommand.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader.GetInt32(0) + " " + reader["RegionDescription"]);
    //Console.WriteLine($"{reader.GetInt32(0)} { reader["RegionDescription"]}");
}

conn.Close();
