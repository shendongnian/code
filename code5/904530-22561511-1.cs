    // Read all Attr elements
    IEnumerable<XElement> subContainerElements = doc.Root.Descendants("SubContainer");
    
    foreach (XElement subContainerElement in subContainerElements)
    {
        // Work with <SubContainer> element here
    }
