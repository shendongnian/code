    var appSettings = ConfigurationManager.AppSettings;
    string sPath = appSettings["ab123"];
    
    //furthermore check for path validity
    if(!string.IsNullOrEmpty(sPath) && System.IO.File.Exists(sPath))    
    { 
       //System.Diagnostics.Process.Start(sPath);
        string[] readText = System.IO.File.ReadAllLines(sPath); //to read the lines in string array     
    }
    
