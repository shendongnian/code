            using (var cn = new SqlConnection(connString))
            {
                cn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE YourTable SET Column = @Parm1 WHERE Col = @Parm2", cn);
                    var parm1 = cmd.CreateParameter("Parm1");
                    parm1.Value =  "SomeValue";
                    var parm2 = cmd.CreateParameter("Parm2");
                    parm2.Value =  "SomeOtherValue";
                    cmd.Parameters.Add(parm1);
                    cmd.Parameters.Add(parm2);
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    //MessageBox.Show(ex.StackTrace);
                }
            }
