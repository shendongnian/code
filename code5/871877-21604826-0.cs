using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Integrated Security=True;Initial Catalog=DB_Name;"))
{
connection.Open();
using (SqlCommand command = connection.CreateCommand()) {
command.CommandText =@"SELECT  Name from Sysobjects where xtype = 'u'";
using (SqlDataReader reader = command.ExecuteReader()) {
      while (reader.Read())
{
// your code goes here...
}
}
  }`
}
