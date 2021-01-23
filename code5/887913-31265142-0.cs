    //HttpContext is a member of `System.Web.Mvc.Controller`,
    //accessible in controllers that inherit from `System.Web.Mvc.Controller`.
    System.Web.HttpFileCollectionBase files = HttpContext.Request.Files;
    string[] fieldNames = files.AllKeys;
    for (int i = 0; i < fieldNames.Length; ++i)
    {
        string field = fieldNames[i]; //The 'name' attribute of the html form
        System.Web.HttpPostedFileBase file = files[i];
        string fileName = files[i].FileName; //The path to the file on the client computer
        int len = files[i].ContentLength;//The length of the file
        string type = files[i].ContentType; //The file's MIME type
        System.IO.Stream stream = files[i].InputStream; //The actual file data
    }
