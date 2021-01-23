     class Program
    {
        static void Main(string[] args)
        {
        StreamReader reader;
        StreamWriter writer = new StreamWriter(/*where you want the final txt to be saved. rename the extension to .cs  */);
            string line;
            int count = 0;
            string[] fileEntries = Directory.GetFiles(/*where your cs files are*/");
            foreach (string fileName in fileEntries)
            {
                // do something with fileName
          
                File.Copy( fileName, /* location to save the now txt .cs files */ + count.ToString() + ".txt");
                count += 1;
            }
            string[] Completetxt = Directory.GetFiles(/*location where you saved the txt files */);
            foreach (string TxtFile in Completetxt)
            {
                reader = new StreamReader(TxtFile);
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    writer.WriteLine(line);
                }
                reader.Close();
            }
        }
    }
