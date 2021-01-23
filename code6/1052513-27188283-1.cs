    public static void CreateXmlFile(IEnumerable<DataType> dataList, string xmlFileName)
        {
            XElement rootElement = new XElement("Root");
            foreach (var group in dataList.GroupBy(d=>new {d.Jaar, d.Week}))
            {
                XElement groepElement = new XElement("Groep");
                groepElement.SetAttributeValue("Jaar", group.Key.Jaar);
                groepElement.SetAttributeValue("Week", group.Key.Week);
                var items = group.Select(ge=>
                    {
                        XElement itemElement = new XElement("Item");
                        itemElement.SetAttributeValue("ID_List", ge.ID_List);
                        itemElement.SetAttributeValue("Notering", ge.Notering);
                        itemElement.SetAttributeValue("Naam", ge.Naam);
                        return itemElement;
                    });
                groepElement.Add(items);
                rootElement.Add(groepElement);
            }
            rootElement.Save(xmlFileName);
        }
