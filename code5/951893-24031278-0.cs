    var connectionString =     
            ConfigurationManager.ConnectionStrings["WingtipToys"].ConnectionString;
    using (var connection = new SqlConnection(connectionString))
     {
       //...
     }
