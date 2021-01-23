    if (string.IsNullOrEmpty(dropdownlist.text) &&
        string.IsNullOrEmpty(textbox.text))
    {
        // ERROR - must specify filter criteria
    }
    // select all cats
    IEnumerable<XElement> cats = xmlDoc.Descendants("cat");
    if (!string.IsNullOrEmpty(dropdownlist.text))
    {
        // filter by category
        cats = cats.Where(c => (string)c.Attribute("id") == dropdownlist.text);
    }
    // select all items in the selected cats
    IEnumerable<XElement> items = cats.SelectMany(c => c.Descendants("item"));
    if (!string.IsNullOrEmpty(textbox.text))
    {
        // filter items by SN
        items = items.Where(i => ((string)i.Element("SN")).Trim() == textbox.text);
    }
    var persons = from item in items
                  select new {
                      SN = person.Element("SN").Value,
                      name = person.Element("name").Value,
                      quantity = person.Element("quantity").Value,
                      description = person.Element("description").Value,
                      price = person.Element("price").Value,
                  };
    // use persons as needed
            
