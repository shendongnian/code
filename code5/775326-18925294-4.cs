        static object moveLocker = new object();
        static void moveToArchive()
        {
            lock (moveLocker)
            {
                System.Threading.Thread.Sleep(2000);  // Give sometime to ensure all file are closed.
                //Environment.CurrentDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
                string applicationPath = System.AppDomain.CurrentDomain.BaseDirectory;
                string archiveBaseDirectoryPath = System.IO.Path.Combine(applicationPath, "Archive");
                if (!Directory.Exists(archiveBaseDirectoryPath)) Directory.CreateDirectory(archiveBaseDirectoryPath);
                String timestamp = DateTime.Now.ToString("yyyyMMddHHmms");
                String outputDirectory = System.IO.Path.Combine(Environment.CurrentDirectory, "Output");
                String destinationTS = System.IO.Path.Combine(archiveBaseDirectoryPath, timestamp);
                try
                {
                    Directory.Move(outputDirectory, destinationTS);                
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not move folder " + outputDirectory + " to: " + destinationTS + "\n" + ex.Message);
                }
            }
        }
