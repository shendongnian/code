    string FolderPath = Server.MapPath("~/App_Data");
    string file = Path.Combine(FolderPath, "textFile.txt");
    //Check if it exist, if not then create the File
    //This is the recommended code by Microsoft
    if (!System.IO.File.Exists(file))
    {
        System.IO.File.Create(file);
    }
