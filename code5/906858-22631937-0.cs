    var doc = XDocument.Parse(save);
    var save = doc.Root;
    Variables.Cookies = long.Parse(save.Element("cookies").Value);
    Variables.clickers = long.Parse(save.Element("clickers").Value);
    etc..
