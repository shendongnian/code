        <Item>
          <ItemInfo>
           <Value>\uE101</Value> //see the added "\" character?
           <Name>1</Name>
          </ItemInfo>
        </Item>
    And the C# code:
        data = (from query in XElement.Load("Data.xml").Descendants("ItemInfo")
        select new ItemInfo
        {
            value = query.Element("Value").Value, //provided value is of string type
            name = query.Element("Name").Value
        }).ToList();
