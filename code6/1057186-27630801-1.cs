    HttpFileCollection MyFiles = Request.Files;
    // ...
    for (int l = 0; l < MyFiles.Count; l++)
    {
        if (MyFiles.GetKey(l) == "file")
        {
            HttpPostedFile file = MyFiles.Get("file");
            // ...
        }
    }
