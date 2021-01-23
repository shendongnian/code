            static object Locker = new object();
            static void moveToArchive()
            {
                lock (Locker)
                {
                    //Environment.CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                    string ApplicationPath = System.AppDomain.CurrentDomain.BaseDirectory;    
                    string DirectoryPath = System.IO.Path.Combine(ApplicationPath, "Archive");
    
                    if (!Directory.Exists(DirectoryPath)) Directory.CreateDirectory(DirectoryPath);
    
                    String timestamp = DateTime.Now.ToString("yyyyMMddHHmms");
                    try
                    {
                        string DestinationTS = System.IO.Path.Combine(DirectoryPath, timestamp);
                        Directory.Move("Output", DestinationTS);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Can not move folder: " + e.Message);
                    }
                }
            }
