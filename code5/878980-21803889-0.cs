    public void Load()
    {
        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        XmlDocument xmldoc = new XmlDocument();
        XmlNodeList xmlnode;
       xmldoc.Load(fs);
       xmlnode = xmldoc.GetElementsByTagName("corpsms");
       for (int i = 0; i < xmlnode.Count; i++)
       {
           string str = string.Format("ID: {0}\r\nName:{0}", xmlnode[i].ChildNodes.Item(0).InnerText, xmlnode[i].ChildNodes.Item(1).InnerText);//Your Data will exist at node 1
           MessageBox.Show(str);
       }
   }
