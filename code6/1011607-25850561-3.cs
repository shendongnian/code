     public void writeLog(string s)
     {
         File.AppendAllText(path,
             DateTime.Now.ToString("dd-MM-yyyy  H:mm:ss         ") + s);        
     }
