    string path = Environment.CurrentDirectory;
    string[] parts = path.Split(@"\".ToCharArray()); 
    var list = parts.TakeWhile(x=>x != "bin").ToList();
    list.Add("Resources");
    list.Add("Thing.csv");
    var pathStr = string.Join(@"/", list.ToArray());
