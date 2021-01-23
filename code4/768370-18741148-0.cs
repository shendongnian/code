    using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
    
                    using (SqlCommand command = new SqlCommand("Select count(ID) from TableName where  ModifyDate>=@Today and ModifyDate<@NextDay", connection))
                    {
                        command.Parameters.Add(new SqlParameter("Today",  DateTime.Today  ));
                        command.Parameters.Add(new SqlParameter("Nextday", DateTime.Today.AddDays(1) ));
    
                        int count = 0;
                        int.TryParse( command.ExecuteScalar().ToString()   , out count);
    
                    }
                }
