                var controller = new BusylightUcController();
                int resultStatus;
                string sqlDataBaseSelect = "SELECT typID FROM az_manager where maID = 4328 ORDER BY datum DESC LIMIT 1";
                string ConnectionString = "Server=localhost; Database=tanss; Uid=root; Pwd=password"; 
                using (MySqlConnection connDataBase = new MySqlConnection(ConnectionString))
                {
                        connDataBase.Open();
						try
						{
							while (true)
							{
								using(MySqlCommand cmd = new MySqlCommand(sqlDataBaseSelect, connDataBase))
								{
									resultStatus = (int)cmd.ExecuteScalar();
									switch(resultStatus)
									{
										case 1: 
											//Console.WriteLine("Debugtext1");                              
											controller.Light(BusylightColor.Green);
											break;
										case 2: 
											//Console.WriteLine("Debugtext2");
											controller.Light(BusylightColor.Red);
											break;
										case 3: 
											//Console.WriteLine("Debugtext3");
											controller.Light(BusylightColor.Red);
											break;
										case 9:
											//Console.WriteLine("Debugtext4");
											controller.Light(BusylightColor.Red);
											break;
										default:
											// handle when its not any of your results.
											break;
									}
								}
								//Console.WriteLine(resultStatus);
								Thread.Sleep(1000);
								//Console.Clear();
							}
						}catch(Exception ex)
						{
							//HandleException
						}finally
						{
							connDataBase.Close(); 
						}    
                }
