                string xmlFile = File.ReadAllText(@"Yourxml.xml");
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(xmlFile);
                XmlNodeList nodeList = xmldoc.GetElementsByTagName("FilingLeadDocument");
                List<info> inforamtion = new List<info>();
                foreach (XmlElement node in nodeList)
                {
                    info inf=new info();
                    inf.RegisterActionDescriptionText = node.GetElementsByTagName("j:RegisterActionDescriptionText")[0].InnerText;
                    inf.DocumentDescriptionText = node.GetElementsByTagName("nc:DocumentDescriptionText")[0].InnerText;
                    inf.DocumentReceivedDate = Convert.ToDateTime(node.GetElementsByTagName("nc:DocumentReceivedDate")[0].FirstChild.InnerText);
                    inforamtion.Add(inf);
                }
       class info
        {
           internal string RegisterActionDescriptionText { get; set; }
           internal string DocumentDescriptionText { get; set; }
           internal DateTime DocumentReceivedDate { get; set; }
        
        }
