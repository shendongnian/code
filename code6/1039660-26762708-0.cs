    var contents = XDocument.Parse(xml);
    
    // Select only elements that have the language attribute
    var result = from item in contents.Descendants()
                 where item.Attribute("language") != null
                 select item;
    // Returns only those elements that have at least another element
    // with the same value.
    var resultDuplicates = result
        .GroupBy(s => s.Value)
        .SelectMany(grp => grp.Skip(1));
    // If duplicates found, replace them in the original xml.
    if (resultDuplicates.Count() > 0)
        resultDuplicates
            .ToList()
            .ForEach(x => xml = xml.Replace(x.ToString(), string.Empty));
