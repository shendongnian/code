    //teamName is a string passed from a session object upon login 
     string filePath = "SFiles/Submissions/" + teamName+ "/";
     string severFilePath = Server.MapPath(filePath);
     // The check here is not necessary as pointed out by @Necronomicron in a comment below
     //if (!Directory.Exists(severFilePath))
     //{ // if it doesn't exist, create
    
        System.IO.Directory.CreateDirectory(severFilePath);
     //}
    
     f_sourceCode.SaveAs(severFilePath + src));
     f_poster.SaveAs(severFilePath + bb));
