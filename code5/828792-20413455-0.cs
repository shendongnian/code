    using(FileStream input = new FileStream(inputFileName,FileMode.Open,FileAccess.Read))
    {
      TextReader reader = new StreamReader(input);
      using (FileStream output = new FileStream(OutputFileName, FileMode.OpenOrCreate, FileAccess.Write))
      {
        TextWriter writer = new StreamWriter(output);
        string line;
        while ((line = reader.ReadLine()) != null)
         {
           writer.WriteLine(line.PadRight(6,' '));
         } 
      }
    }
