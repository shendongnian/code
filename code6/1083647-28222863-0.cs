            try
            {
                var xDoc = new XmlDocument();
                string file = "input.xml";
                int batchSize = 2;
                if(File.Exists(file))
                {
                    xDoc.Load(file);
                    var elements = xDoc.DocumentElement.SelectNodes("/root/elements/element");
                    if(elements!=null && elements.Count>batchSize)
                    {
                        var elementsToRetain = elements.OfType<XmlNode>().Take(batchSize);
                        var elementsNode = xDoc.DocumentElement.SelectSingleNode("/root/elements");
                        elementsNode.RemoveAll();
                        
                        foreach(var ele in elementsToRetain)
                        {
                            elementsNode.AppendChild(ele);
                        }
                    }
                    xDoc.Save("output.xml");
                }
            }
            catch (Exception e)
            {
            }
