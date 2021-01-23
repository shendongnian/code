    var root = JsonConvert.DeserializeObject<RootObj>(json);
    Print(root.roots.bookmark_bar,"");
 
    void Print(Node n,string padding)
    {
        Console.WriteLine(padding + "+" + n.name);
        foreach(var url in n.children.Where(c => c.type == "url"))
        {
            Console.WriteLine(padding + "\t-" + url.name);
        }
        foreach (var folder in n.children.Where(c => c.type == "folder"))
        {
            Print(folder, padding + "\t");
        }
    }
