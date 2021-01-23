    var serverPath = Path.Combine(Server.MapPath("~") , "Date " + getShamsiDate().Replace("/", "-") +
    				" Time " + DateTime.Now.Hour.ToString() + "." +
    				DateTime.Now.Minute.ToString() + "." + 
    				DateTime.Now.Second.ToString());
    
    if (!Directory.Exists(serverPath))
    {
        Directory.CreateDirectory(serverPath);
    }
    
    fl.SaveAs(Path.Combine(serverPath, f1.FileName);
