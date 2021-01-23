    List<string[]> File1 = Parse("File1Path");
    List<string[]> File2 = Parse("File2Path");
    
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(OutputFile))
    {
       // write header first:    
       file.WriteLine("Name, Surname, Locality, DateOfBirth, Age");
    
       foreach (string line in File1)
       {
         var found = File2.Where(x => x[0] == line[0]).FirstOrDefault();         
         if(null == found) continue;
    
         file.WriteLine(string.Format("{0},{1},{2},{3},{4}",
                                    line[0], line[1], found[3], found[4], line[2]));
        }
    }
