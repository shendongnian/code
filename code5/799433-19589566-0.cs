                try
                {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = null;
                SqlDataReader rdr = null;
                conn.Open();
                cmd = new SqlCommand(sqlsel, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                  var _id = rdr.GetInt(0);
                }
                conn.Close();
                
                 // do something with _id
