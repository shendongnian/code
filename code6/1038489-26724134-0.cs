            using System.Xml.Linq;
            XDocument myDoc = XDocument.Load(".\\Main.xml");
            XElement filterNode = myDoc.Root.Element("entity").Element("filter");
            // Example element to add
            XElement newCondition = new XElement("condition");
            newCondition.SetAttributeValue("attribute", "parentcustomerid");
            newCondition.SetAttributeValue("operator", "eq");
            filterNode.Add(newCondition);
            myDoc.Save(".\\newFile.xml");
