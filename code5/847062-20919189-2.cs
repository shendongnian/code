    static void Main(string[] args)
            {
                HashSet<string> set = new HashSet<string>();
                XmlDocument doc = new XmlDocument();
                doc.Load("original.xml");
    
                XmlDocument doc2 = new XmlDocument();
                doc2.Load("update.xml");
    
                var nodesoriginal = doc.SelectNodes("/blocker/lst");
                var nodesupdate = doc2.SelectNodes("/blocker/lst");
    
                var List = nodesoriginal.Cast<XmlNode>().Concat<XmlNode>(nodesupdate.Cast<XmlNode>());
    
                foreach (XmlNode element in List)
                {
                    string value = element.InnerText;
                    if (value != null && !set.Contains(value))
                    {
                        set.Add(value);
                    }
                }
    
                XmlDocument output = new XmlDocument();
                XmlElement blocker = output.CreateElement("blocker");
                foreach(var str in set)
                {
                    XmlElement node = output.CreateElement("lst");
                    node.InnerText = str;
                    blocker.AppendChild(node);
                }
    
                output.AppendChild(blocker);
    
                output.Save("output.xml");
                output.Save(Console.Out);
                Console.ReadKey();
            }
