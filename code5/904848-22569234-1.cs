    using(var sqlCon1 = new SqlConnection("PRIVATE"))
    using (var sqlCmd1 = new SqlCommand())
    {
        sqlCmd1.CommandText = "Select AccStatus From PDMStatus WHERE Data = 'ToBeWebEnabled8'";
        sqlCmd1.Connection = sqlCon1;
        sqlCon1.Open();
        using (var reader = sqlCmd1.ExecuteReader())
            Button1.Enabled = reader.HasRows;
    }
