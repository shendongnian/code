    public void DoStuff(string fileName, List<string> linesToBeWritten)
    {
       var output = new List<string>();
       
       if (!File.Exists(fileName))
        return;
    
       output.Add("<" + fileName + ">");
       output.AddRange(linesToBeWritten); 
       output.Add("</" + fileName + ">");
    
       File.WriteAllLines(fileName, output);
    }
