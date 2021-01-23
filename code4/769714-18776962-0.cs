    List<string> myStringColumn= new List<string>();
    using (var fileReader = File.OpenText(inFile))
        using (var csvResult  = new CsvHelper.CsvReader(fileReader))
        {
            while (csvResult.Read())
           {
             string stringField=csvResult.GetField<string>("Header Name");
             myStringColumn.Add(stringField);    
           }
        }
     
