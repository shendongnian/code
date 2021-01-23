    var paragraph = d.Paragraphs.FirstOrDefault(); // or [0] if you're not using Linq
    var pInfo = paragraph.GetType().GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(p => p.Name == "Rectangle");
    if(pInfo != null)
    {
        var val = pInfo.GetValue(paragraph) as Rectangle; // or whatever the actual type of that property is
    }
