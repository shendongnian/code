    var allStrings = new List<string>();
    allStrings.Add("aaa");
    allStrings.Add("bbb");
    allStrings.Add("ccc");
    // ...
    
    using (StreamWriter w = File.AppendText(path))
    {
       foreach(string str in allStrings)
           w.WriteLine(str );
    }
