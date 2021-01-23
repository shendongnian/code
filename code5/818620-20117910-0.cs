    var root =  new DirectoryInfo(Path.GetDirectoryName(Application.ExecutablePath)).Parent.Parent;
    var allXsdFiles = root.EnumerateFiles(".xsd", SearchOption.AllDirectories);
    DataTable tblFiles = new DataTable();
    tblFiles.Columns.Add("Filename");
    tblFiles.Columns.Add("Directory");
    foreach (FileInfo xsd in allXsdFiles)
        tblFiles.Rows.Add(xsd.Name, xsd.Directory);
