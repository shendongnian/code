    List<string> lines = new List<string>();
    using (var f0 = new FileStream(Server.MapPath("./key.txt"), FileMode.Open, FileAccess.Read))
    {
        string line;
        using (StreamReader reader = new StreamReader(f0))
        {
            while ((line = reader.ReadLine()) != null)
            {    
                lines.add(line);
            }
        }
    }
    
    // it would need to be a very big text file to be a memory issue
    // do your processing here
 
