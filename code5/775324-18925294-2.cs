        static object moveLocker = new object();
        static void moveToArchive()
        {
            lock (moveLocker)
            {
                //Environment.CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                string applicationPath = System.AppDomain.CurrentDomain.BaseDirectory;
                string archiveBaseDirectoryPath = System.IO.Path.Combine(applicationPath, "Archive");
                if (!Directory.Exists(archiveBaseDirectoryPath)) Directory.CreateDirectory(archiveBaseDirectoryPath);
                String timestamp = DateTime.Now.ToString("yyyyMMddHHmms");
                String outputDirectory = System.IO.Path.Combine(applicationPath, "Output");
                try
                {                    
                    string destinationTS = System.IO.Path.Combine(archiveBaseDirectoryPath, timestamp);
                    Directory.Move(outputDirectory, destinationTS);                
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not move folder Output to: " + destinationTS + "\n" + ex.Message);
                }
            }
        }
