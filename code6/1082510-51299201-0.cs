       SqlConnectionStringBuilder sqlb = new SqlConnectionStringBuilder("");
            sqlb.ContextConnection = true;
            string newConnStr = sqlb.ToString();
            using (SqlConnection c = new SqlConnection(newConnStr))
            {
                c.Open();
                //This is the database name
                DatabaseName = c.Database;
                //We need to use some simple SQL to get the server and instance name.
                //Returned in the format of SERVERNAME\INSTANCENAME
                SqlCommand cmd = new SqlCommand("SELECT @@SERVERNAME [Server]", c);
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    ServerName = rdr["Server"].ToString();
                }
            }
