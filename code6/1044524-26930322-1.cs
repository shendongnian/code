    SPFile file = mylibrary.Files.Add(System.IO.Path.GetFileName
                                           (FileUpload1.PostedFile.FileName), byt,      
                 SPContext.Current.Site.RootWeb.CurrentUser, 
                 SPContext.Current.Site.RootWeb.CurrentUser, 
                 System.DateTime.Now, System.DateTime.Now);
    file.CheckIn();
    // Get a SPListItem for the document
    SPListItem item = file.Item;
    item.File.CheckOut();
    item["Title"] = "MyFile_Name";
    item["Author"] = "My_Name";
    //etc…
    item.Update();
    item.File.CheckIn("Application generated file metadata.");
