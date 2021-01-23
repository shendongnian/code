    // (I added "root", otherwise the xml is invalid)
    string original = "<root><series id=\"S000002334Member\"><class id=\"C000006118Member\" /></series><series id=\"S000002334Member\"><class id=\"C000006119Member\" /></series></root>";            
    XElement originalXml = XElement.Parse(original);
    var groups = originalXml              
        .Descendants("series")
        .GroupBy(a => a.Attribute("id").Value); // that's the important bit...
    IEnumerable<XElement> afterGrouping = groups
        .Select(
            grp => // for each group...
                new XElement( // ...create a new element
                    "series", 
                    new XAttribute("id", grp.Key), 
                    grp.Select(each => each.Element("class")))); // containing all "class" elements from the group
    XElement final = new XElement("final", afterGrouping); // just adding root element again
    // and the result is:
    //
    // <final>
    //     <series id="S000002334Member">
    //         <class id="C000006118Member" />
    //         <class id="C000006119Member" />
    //     </series>
    // </final>
