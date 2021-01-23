    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\FunkyName\Desktop";
            string[] txtFiles = Directory.GetFiles(filePath, "*.txt");
            using (Stream stream = File.Open(string.Format(@"{0}\{1}", filePath, "result.txt"), FileMode.OpenOrCreate))
            {
                for (int i = 0; i < txtFiles.Length; i++)
                {
                    string fileName = txtFiles[i];
                    try
                    {
                        using (Stream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                        {
                            fileStream.CopyTo(stream);
                        }
                    }
                    catch (IOException e)
                    {
                        // Handle file open exception
                    }
                }
            }
        }
    }
