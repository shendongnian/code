     public void writeLog(string s)
     {
         File.WriteAllText(path,
             DateTime.Now.ToString("dd-MM-yyyy  H:mm:ss         ") + s);        
     }
