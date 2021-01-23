    class Testing
    {
        public static void Main()
        {
            string fileName = "TestFile.txt";
            while (true)
            {
                if(File.Exists(fileName))
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        String line = sr.ReadToEnd();
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Waiting for new file...");
                }
                File.Delete(fileName);               
                
                Thread.Sleep(5000);
            }
        }
    }
