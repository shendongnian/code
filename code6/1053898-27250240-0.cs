          public List<string> EditorialResponse(string fileName, string searchString,                  string replacementString)
        {
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Replace(searchString, replacementString);
                    list.Add(line);
                    Console.WriteLine(line);
                }
                reader.Close();
            }
            return list;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TextImportEdit tie = new TextImportEdit();
            List<string> ls = tie.EditorialResponse(@"C:\Users\Tom\Documents\Visual Studio 2013\story.txt", "tea", "cockrel");
            StreamWriter writer = new StreamWriter(@"C:\Users\Tom\Documents\Visual Studio 2013\story12.txt");
            foreach (string line in ls)
            {
                writer.WriteLine(line);
            }
            writer.Close();
        }
    }
}
