    var conString = "MyConnectionString";
    
    using (var con = new SqlConnection(conString))
    {
        con.Open();
    
        var sql = string.Format("insert into MyTable(somestuff) values('{0}'))",myData);
    
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
