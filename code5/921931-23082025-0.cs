    bool found=false;
    List<String> lines = new List<String>();
    foreach(var line in File.ReadLines(@"C:\MyFile.txt"))
    {
     
     if(found)
     {
       lines.Add(line);
     }
     if(!found && line.Contains("UNIQUEstring"))
     {
       found=true;
     }
    
    }
