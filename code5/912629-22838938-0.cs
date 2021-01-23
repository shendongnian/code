    private static void MergeResource()
        {
            var userDocument = XDocument.Load(@"resource.user.resx");
            var userData = userDocument.Root.Elements().Where(e => e.Name == "data");
    
            var originalDocument = XDocument.Load(@"resource.resx");
            var origData = originalDocument.Root.Elements().Where(e => e.Name == "data");
            var notMatchedData = origData.Where(oe => userData.All(ue => ue.Attribute("name").Value != oe.Attribute("name").Value));
    
            foreach (var data in notMatchedData)
                userDocument.Root.Add(data);
    
            userDocument.Save("Resource.resx", SaveOptions.None);
        }
