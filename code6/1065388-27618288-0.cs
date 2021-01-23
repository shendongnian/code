    XDocument doc = XDocument.Parse(e.Result);
    List<LIST> list = new List<LIST>();
    var nodes = doc.Descendants("row").ToList();
     for (int i = 0; i < nodes.Count; i++)
     {
        string newid = nodes[i].Element("Id").Value;
        string uri = "https://www.XYZ.com/abc/getDocument.htm?username=" + name + "&password=" + pwd + "&Id=" + newid;
        list.Add(new LIST() { isImage = uri});
     }
     listBox1.DataContext = list;
