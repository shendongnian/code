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
    var persons = from person in items
                  select new
                  {
                      SN = (string)person.Element("SN"),
                      name = (string)person.Element("name"),
                      quantity = (string)person.Element("quantity"),
                      description = (string)person.Element("description"),
                      price = (string)person.Element("price"),
                  };
    // use persons as needed
            
