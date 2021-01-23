    public static bool HasElement(this XElement source, string elementName)
    {
          return source.Element(elementName) != null;
    }
    xElemMaster.Elements("entries")
                .Elements("entry")
                .Where(elem => elem.Element.HasElement("isExtracted"));
