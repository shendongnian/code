            XDocument doc;
            using (Stream input = System.IO.File.OpenRead("XMLFile1.xml"))
            {
                doc = XDocument.Load(input);
                XmlNamespaceManager nm = new XmlNamespaceManager(new NameTable());
                XNamespace ns = doc.Root.GetDefaultNamespace();
                nm.AddNamespace("ns", ns.NamespaceName);
                foreach (var hostedService in doc.Root.XPathSelectElements("ns:HostedService",nm)) // loop through all events
                {
                    if (hostedService.XPathSelectElement("ns:ServiceName", nm) != null)
                    {
                        var service = hostedService.XPathSelectElement("ns:ServiceName",nm).Value;
                    }
                    if (hostedService.XPathSelectElement("ns:Url",nm) != null)
                    {
                        var url = hostedService.XPathSelectElement("ns:Url",nm).Value;
                    }
                }
            }
