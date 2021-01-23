    using (var reader = new StringReader(xml))
                {
                    var element = XElement.Load(reader);
    
                    var toBeRemovedElements = element.Elements().Where(e => e.Value == parameter).ToList();
    
                    toBeRemovedElements.ForEach(e => e.Remove());
                }
