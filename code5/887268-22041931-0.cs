    var dataSets = new DataSet();
            using (var connx = new SqlConnection(LastUsedConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand("Select * from DCR", connx);
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dataSets);
                }
                finally
                {
                    connx.Close();
                }
            }
