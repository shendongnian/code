    foreach (var item in System.IO.Directory.GetFiles(@"C:\TempFolder"))
    {
    	string name = new System.IO.FileInfo(item).Name;
    	string newName = name.Insert(name.IndexOf("."), "_new");
    	System.IO.File.Move(item, System.IO.Path.Combine(@"C:\Images", newName));
    }
