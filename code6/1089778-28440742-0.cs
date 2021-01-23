        static void Main(string[] args)
        {
            string inputText = string.Empty;
            //string directory = Environment.CurrentDirectory;
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = Path.Combine(directory, "url.txt");
            if (File.Exists(path))
            {
                TextReader tr = new StreamReader(path);
                string readUrl = tr.ReadLine().ToString();
                inputText = readUrl;
                tr.Close();
            }
            
            string text = "abc";
            TextWriter ts = new StreamWriter(path);
            ts.WriteLine(text);
            ts.Close();
        }
