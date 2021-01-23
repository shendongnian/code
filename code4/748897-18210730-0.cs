    string[] lines  = File.ReadAllLines("yourfile.csv");
    List<string> linesToWrite = new List<string>();
    int currentCount = 0;
    
    foreach(string s in lines)
    {     
      if(s.Contains("YourKeyValue"))
         linesToWrite.Add(s);  
    }
    File.WriteAllLines("yourfile.csv", linesToWrite );
   
 
