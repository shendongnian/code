    FileInfo file = new FileInfo("myfile.csv");
    using (TextReader reader = file.OpenText())
    {
        for(String line = reader.ReadLine(); line != null; line = reader.ReadLine())
        {
             string[] fields = line.Split(new[] {','});
             foreach(String f in fields)
             {
                 //do whatever you need for each field
              }
         }
     }
