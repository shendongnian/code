    var outputFormats = new List<string>();
    foreach (var t in types)
    {
	var prop = t.GetFields().First(i => i.Name == "outputFormat");
        outputFormats.Add(prop.GetValue(null));
    }
