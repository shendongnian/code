    public JsonResult Read(string path)
    {
        const string StartDirectory = @"C:\";
        path = path ?? StartDirectory;
        var files = Directory.GetFiles(path).Select(file => 
            new KendoTreeViewViewModel
                {
                    Id = file,
                    HasChildren = false,
                    Name = Path.GetFileName(file)
                });
        var directories = Directory.GetDirectories(path).Select(dir =>
            new KendoTreeViewViewModel
                {
                    Id = dir,
                    HasChildren = true,
                    Name = Path.GetFileName(dir)
                });
        var result = files.ToList();
        result.AddRange(directories);
        result = result.OrderBy(x => x.HasChildren).ToList();
        return this.Json(result, JsonRequestBehavior.AllowGet);
    }
