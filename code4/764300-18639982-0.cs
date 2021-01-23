       XmlDocument dddd = new XmlDocument();
                dddd.Load(@"D:\Development\xxxx\xxxxx.xml");
                XmlNode xnode = dddd.DocumentElement;
                for (int i = 0; i < xnode.ChildNodes.Count; i++)
                { 
                   if(xnode.ChildNodes[i].Attributes !=null)
                       foreach (XmlAttribute a in xnode.ChildNodes[i].Attributes)
                       {
                           if (a.Name == "ows_Content_x0020_Description")
                           {
                               string nameddd = a.InnerText;
                           }
                       }
                
                }
