    List<Person> pers = new List<Person>();
    public class Person
    {
      public string id { get; set; }//1
      public string name { get; set; }//2
      public string bilno { get; set; }//3
      public string mob { get; set; }//4
      public DateTime dt { get; set; }//5
    }  
    string path=@"c:\.....";
    void save()
    {
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(path + @"\data.xml");
        XmlNode xnode = xdoc.SelectSingleNode("Items");
        xnode.RemoveAll();
        foreach (Person i in pers)
        {
            XmlNode xtop = xdoc.CreateElement("Item");
            XmlNode x1 = xdoc.CreateElement("a");
            XmlNode x2 = xdoc.CreateElement("b");
            XmlNode x3 = xdoc.CreateElement("c");
            XmlNode x4 = xdoc.CreateElement("d");
            XmlNode x5 = xdoc.CreateElement("e");
            x1.InnerText = i.id;
            x2.InnerText = i.name;
            x3.InnerText = i.bilno;
            x4.InnerText = i.mob;
            x5.InnerText = i.dt.ToFileTime().ToString();
            xtop.AppendChild(x1);
            xtop.AppendChild(x2);
            xtop.AppendChild(x3);
            xtop.AppendChild(x4);
            xtop.AppendChild(x5);
            xdoc.DocumentElement.AppendChild(xtop);
        }
        xdoc.Save(path + @"\data.xml");
    }
    void load()
    {
        XmlDocument xdoc = new XmlDocument();
        xdoc.Load(path + @"\data.xml");
        foreach (XmlNode xnode in xdoc.SelectNodes("Items/Item"))
        {
            Person p = new Person();
            p.id = xnode.SelectSingleNode("a").InnerText;
            p.name = xnode.SelectSingleNode("b").InnerText;
            p.bilno = xnode.SelectSingleNode("c").InnerText;
            p.mob = xnode.SelectSingleNode("d").InnerText;
            p.dt = DateTime.FromFileTime(Convert.ToInt64(xnode.SelectSingleNode("e").InnerText));
        }
    }
