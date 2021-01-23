    class FileInfo
    {
    	public string Extension { get; set; }
    	public string IconPath { get; set; }
    	public string Editable { get; set; }
    }
    
    //somewhere inside you class
    var files = new List<FileInfo>();
    files.Add(new FileInfo(){ Extension = ".txt", IconPath = "<img src='pic/pe.png'/>", Editable = true});
    // do this for all extensions
    
    var fileInfo = file.First(f => f.Extension.Equals(fileExtension))
    ((Label)e.Item.FindControl("imagelabel")).Text = fileInfo.IconPath;
    if(fileInfo.Editable)
    {
    	((LinkButton)e.Item.FindControl("lbtnEditText")).Text = "<img src='pic/pe.png'/> Edit Text";
    }
