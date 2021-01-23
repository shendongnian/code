      using (var streamReader = new StreamReader(filePath))
      {
        string line;
        while ((line = streamReader.ReadLine()) != null)
        {
          Console.WriteLine(line);
        }
      }
