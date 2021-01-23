    string s = "goeirjew98rut34ktljre9t30t4j3der";
    var outputs = new List<string>();
    for (var i = 0; i < s.Length; i += 8)
    {
        string sub = s.Substring(i, Math.Min(8, s.Length - i));
        if(sub.Length > 3)
            sub = sub.Insert(3, "_");
        if (sub.Length > 8)
            sub = sub.Insert(8, "_");
        outputs.Add(sub);
    }
