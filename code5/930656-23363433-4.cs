     using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(yourconnectionstring))
                {
                    conn.Open();
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query , conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    youttextbox.Text = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
