    public void IsMovieInStore()
                    {
                        Console.Write("Searh for a movie title: ");
                        string title = Console.ReadLine();
            
                        string connectionString = @"Data Source=|DataDirectory|\VideoStoreDB.sdf";
                        SqlCeConnection connection = new SqlCeConnection(connectionString);
            
                        SqlCeCommand command = new SqlCeCommand("SELECT Movie.Title, MovieHandler.InStore FROM Movie INNER JOIN MovieHandler ON Movie.MovieCodeLable = MovieHandler.MovieCodeLable WHERE MovieHandler.InStore = 1 AND Movie.Title = @title", connection);
                        command.Parameters.AddWithValue("@title", title);
            
                        SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter(command);
            
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
            
            If(dataTable != null && dataTable.Rows.Count>0)
            {
                         foreach (DataRow row in dataTable.Rows)
                            {
                                foreach (DataColumn column in dataTable.Columns)
                                {
                                    Console.WriteLine(column.ColumnName + ": " + row[column]);
                                }
                                Console.WriteLine("-------------------------");
                            }
                      }
        }
            else{
              Console.WriteLine("Empty result");
            }
                        Console.ReadLine();
                    }
