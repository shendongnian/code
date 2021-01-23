    var doc = new XPathDocument(Application.StartupPath + "/DBConn.xml");
    var navigator = doc.CreateNavigator();
    var serverName = navigator.SelectSingleNode("//appsettings/servername");
    var username = navigator.SelectSingleNode("//appsettings/username");
    var password = navigator.SelectSingleNode("//appsettings/password");
    var database = navigator.SelectSingleNode("//appsettings/database");
    using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=" + serverName + ";Initial Catalog=" + database + ";User Id=" + username + ";Password=" + password + ";MultipleActiveResultSets = True"))
    {
    SqlCommand cmd = new SqlCommand("use TelecomNames SELECT xName FROM dbo.Character", connection);
    connection.Open();
    cmd.ExecuteNonQuery();
    SqlDataReader reader = cmd.ExecuteReader();
    AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
    while (reader.Read())
    {
    }
    connection.Close();
    }
