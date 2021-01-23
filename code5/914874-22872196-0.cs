        static void LogThis(string logMessage)
        {
            Console.WriteLine(logMessage);
            using (StreamWriter writer = new StreamWriter(FileDate() + ".txt", true))
            {
                writer.WriteLine(logMessage);
                writer.WriteLine();
            }
        }
        static string FileDate()
        {
            return DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd");
        }
