    namespace MoveFiles
    {
    class Program
    {
        public static string destinationPath = @"S:\Re\C";
        static void Main(string[] args)
        {
           
            //location of PDF files
            while (true)
            {
                string path = @"S:\Can\Save";
                //get ONLY PDFs
                string[] filePath = Directory.GetFiles(path, "*.pdf");
                foreach (string file in filePath)
                {
                    Console.WriteLine(file);
                    string dest = destinationPath + "\\" + Path.GetFileName(file);
                    File.Move(file, dest);
                }
                Thread.Sleep(60000);
            }
            
        }
        
    }
    }
