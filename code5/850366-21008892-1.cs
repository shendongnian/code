        static void Main(string[] args)
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "textfile.txt");
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                //if the file doesn't exist, create it
                if (!File.Exists(fileName))
                    File.Create(fileName);
                for (int i = 0; i < 2; i++)
                {
                    file.WriteLine("asdas2");
                }
            }
            using(System.IO.StreamReader fr = new StreamReader(fileName))
            {
                Console.WriteLine(fr.ReadToEnd());
            }
        }
