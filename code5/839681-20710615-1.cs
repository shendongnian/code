    SqlConnection sqlCon3 = new SqlConnection("REMOVED");
                    SqlCommand sqlCmd3 = new SqlCommand();
                    sqlCmd3.CommandText = "INSERT INTO [Products].[Features] ([ProductID] ,[Title] ,[ViewOrder]) VALUES (@myID, @myTitle, NULL) ";
                    sqlCmd3.Connection = sqlCon3;
                    sqlCon3.Open();
                    for (int i = 0; i < 10; i++)
                    {
                        sqlCmd3.Parameters.Add("myID", SqlDbType.Int).Value = myobjID[i];
                        sqlCmd3.Parameters.Add("myTitle", SqlDbType.Text).Value = myobjTitle[i];
                        sqlCmd3.ExecuteNonQuery();
                        sqlCmd3.Parameters.Clear();
                    }
                                       
                    sqlCon3.Close();
