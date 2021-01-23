      public static void changeFile(string InputPath,string OutputPath)
        {
    
                List<string> OUTPUT = new List<string>();
                StreamReader sr = new StreamReader(InputPath);
                while (!sr.EndOfStream)
                {
                    OUTPUT.Add(sr.ReadLine());
                }
                sr.Close();
                StreamWriter fs = new StreamWriter(OutputPath);
                string output = "";
    
                foreach (string line in OUTPUT)
                {
                    output += line + " ";
                }
                fs.WriteLine(output);
                fs.Close();
    }
