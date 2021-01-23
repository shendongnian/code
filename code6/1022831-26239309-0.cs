    foreach (string file in files)
                {
                    var fileInfo = new FileInfo(file);
    
                    Console.WriteLine("Running script {0}", fileInfo.Name);
    
                    string text = fileInfo.OpenText().ReadToEnd();
    
                    using (var conn = new SqlConnection(connectionString))
                    {
                        using (var cmd = new SqlCommand(text, conn))
                        {
                            conn.Open();
    
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }
                }
