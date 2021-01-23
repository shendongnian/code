        private static object locker = new object();
        private static void WriteMessageToFile(string message)
        {
            string dateStr = DateTime.Now.Date.Day.ToString()+"_"+ DateTime.Now.Date.Month.ToString()+"_"+ DateTime.Now.Date.Year.ToString();
            if (!Directory.Exists("Logs"))
            {
                DirectoryInfo di = Directory.CreateDirectory("Logs");
            }
            //Guid guidGenerator = Guid.NewGuid();
            string filePath = _env.ContentRootPath + "\\Logs\\ProcessLog_" + dateStr + ".txt";
            FileInfo fi = new FileInfo(filePath);
            lock (locker)
            {
                using (FileStream file = new FileStream(fi.FullName, FileMode.Append, FileAccess.Write, FileShare.Read))
                using (StreamWriter streamWriter = new StreamWriter(file))
                {
                    streamWriter.WriteLine(message);
                    streamWriter.Close();
                }
            }
        }
