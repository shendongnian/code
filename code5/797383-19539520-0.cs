    var subjectDictionary = certificate.Subject
        .Split(new[] { ", " }, StringSplitOptions.None)
        .Select(pair => pair.Split('='))
        .ToDictionary(pair => pair[0], pair => pair[1])
    
    if (subjectDictionary.ContainsKey("C"))
    {
       var valueForC = subjectDictionary["C"];
       …
    }
