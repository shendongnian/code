    var ff = Directory.GetFiles(fileImportFolder, "*", SearchOption.AllDirectories);
    foreach (var f in ff)
    {
        // f is a full path of the file
        Response.Write(f.ToString());
    
        // use FileInfo to get specific attributes   
        var i = new FileInfo(f);
        Response.Write("SubCategoryId=" + i.Directory.Name);
        Response.Write("CategoryId=" + i.Directory.Parent.Name);
        Response.Write("UpdateDate=" + i.LastWriteTime.ToString());
        ...
    }
