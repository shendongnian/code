            foreach (var query in sqlqry)
            {
                try
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    string logPath = ""; //Path for log
                    using (StreamWriter writer = new StreamWriter(logPath, true))
                    {
                        writer.WriteLine("Ran query " + query); //W
                    }
                    System.Windows.Forms.MessageBox.Show("Patch executed successful. Please send Result Log to Support // Need to create the result log file.");
                }
                catch (Exception ex)
                {
                    //Handle Error
                }
            }
