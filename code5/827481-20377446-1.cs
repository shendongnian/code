    var cString = ConfigurationManager
        .ConnectionStrings["train_debConnectionString"]
        .ConnectionString;
    using (SqlConnection c = new SqlConnection(cString))
    {
        using (SqlCommand cmd = new SqlCommand(sqlCmd, c))
        {
        }
    }
