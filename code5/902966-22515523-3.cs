                 var xElem = XElement.Load("XML/books.xml");
                 var result=
                    from elem in xElem.Descendants("Word")
                    orderby elem.Attribute("name").Value
                    select new Book
                    {
                        Name = elem.Attribute("name").Value,
                        Id = elem.Element("Id").Value, 
                     
                    };
                
