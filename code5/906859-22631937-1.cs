    var doc = XDocument.Parse(save);
    var root = doc.Root;
    Variables.Cookies = long.Parse(root.Element("cookies").Value);
    Variables.clickers = long.Parse(root.Element("clickers").Value);
    etc..
