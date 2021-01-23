    var document = XDocument.Load(file);
                
    var namespaces = new XmlNamespaceManager(new NameTable());
                    
    namespaces.AddNamespace("ns", document.Root.GetDefaultNamespace().NamespaceName);
    var filenamesXPath = "/ns:session/*[ns:result[@success='true']]/ns:filename";
    var filenames = document.XPathSelectElements(filenamesXPath, namespaces);
