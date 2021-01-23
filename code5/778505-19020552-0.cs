    var resource1 = XDocument.Load("C:\\Resources.resx");
    var resource2 = XDocument.Load("C:\\Resources2.resx");
    foreach (XElement node in resource2.Root.Elements())
    {                    
        if (resource.Root.Contains(node)) continue;
        resource1.Add(node);
    }
    resource1.Save("C:\\FinalResources.resx");
    public static class XElementExtensions
    {
        public static bool Contains(this XElement root, XElement e)
        {
            //or w/e equality logic you need
            return root.Elements().Any(x => x.ToString().Equals(e.ToString()));
        }
    }
