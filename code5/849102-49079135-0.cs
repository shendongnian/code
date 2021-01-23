    List<string> xmlList = new List<string>();
            xmlList.Add("FIXML");
            xmlList.Add("Header");
            xmlList.Add("RequestHeader");
            xmlList.Add("RequestUUID");
            
            XElement parentNode = null;
            string lastParent = null;
            foreach (var item in xmlList)
            {
                if (parentNode == null)
                {
                    parentNode = new XElement(item);
                    lastParent = XmlConvert.EncodeName(item);
                }
                else
                {
                    var ln = parentNode.DescendantsAndSelf().FirstOrDefault(x => x.Name.LocalName == lastParent);
                    ln.Add(new XElement(XmlConvert.EncodeName(item)));
                    lastParent = XmlConvert.EncodeName(item);
                }
            }
            Console.WriteLine(parentNode);
            Console.ReadLine();
