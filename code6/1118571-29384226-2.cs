    List<string> _list = new List<string>()
                        {
                            "address_City",
                            "first_name"
                        };
    List<string> _displayList = new List<string>();
    if (entityMetaData.Attributes.Any())
    {
        _displayList.AddRange(from lName in _list 
                              select (entityMetaData.Attributes.FirstOrDefault(n => n.LogicalName.Equals(lName))) 
                              into attribute 
                              where attribute.DisplayName.UserLocalizedLabel != null 
                              select attribute.DisplayName.UserLocalizedLabel.Label);
    }
