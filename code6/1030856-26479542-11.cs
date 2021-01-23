    [HttpGet]
    public IList<string> GetFolderNames(int id)
    {
        //FIND ALL FOLDERS IN FOLDER with in own project
        string location = System.Web.HttpContext.Current.Server.MapPath("parent folder name");
    
        //For fixed path location will be like as string location =@"E:\Target Folder\";
    
        System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(location);
        var folderList = new List<string>();
    
        foreach (System.IO.DirectoryInfo g in dir.GetDirectories())
        {
            //LOAD FOLDERS 
            folderList.Add(g.FullName);
        }
    
        return folderList;
    }
