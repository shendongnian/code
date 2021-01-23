     XDocument doc = XDocument.Load(path);
    
                IList<string> list=new List<string>();
    
                IEnumerable<XElement> contentElements = doc.Descendants("content");//this get all "content" tags
                IEnumerable<XElement> contentValueElements = contentElements.Descendants("contentValue");//this get all "contentValue" tags
    
                foreach (XElement i in contentValueElements)
                {
                  
                        list.Add(i.Value);
                }
