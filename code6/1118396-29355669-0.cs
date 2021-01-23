                string namespaceName = "http://schemas.hp.com/SM/7";
                XDocument xdoc = XDocument.Load(path);
                var authors = xdoc.Descendants(XName.Get("instance", namespaceName));
    
                foreach (var author in authors)
                {
                    string ciName = author.Descendants(XName.Get("CIName", namespaceName)).First().Value;
                    string type = author.Descendants(XName.Get("Type", namespaceName)).First().Value;
                    string frendlyName = author.Descendants(XName.Get("Type", namespaceName)).First().Value;
                    string accountNo = author.Descendants(XName.Get("AccountNo", namespaceName)).First().Value;
                    Console.WriteLine("{0}, {1}, {2}, {3}", ciName, type, frendlyName, accountNo);
                }
