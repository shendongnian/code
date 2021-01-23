     public void writeLog(string s)
     {
        using (StreamWriter sw = File.AppendText(path)) 
        {
            sw.WriteLine(DateTime.Now.ToString("dd-MM-yyyy  H:mm:ss         ") + s);
        }	
    }
