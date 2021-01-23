    FileInfo file = new FileInfo("myfile.csv");
    using (TextReader reader = file.OpenText())
    using (CsvReader csv = new CsvReader(reader))
    {
         csv.Configuration.Delimiter = ",";
         csv.Configuration.HasHeaderRecord = false;
         csv.Configuration.IgnoreQuotes = true; //if you don't use field quoting
         csv.Configuration.TrimFields = true; //trim fields as you read them
         csv.Configuration.WillThrowOnMissingField = false; //otherwise null fields aren't allowed
         csv.Configuration.RegisterClassMap<MyClassMap>(); //adds our mapping class to the reader
         while(csv.Read())
         {
             myObject = csv.GetRecord<MyClass>();
             //do whatever here
         }
    }
    
