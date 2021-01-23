    var objects = xmlDoc.Descendants("object");
    var items = 
      objects
        .Select(item => 
          new Script
          {
            Id = item.Attribute("Id").Value,
            Expression = item.Descendant("Expression").Content.Value,
            Results = 
              item
                .Descendants("Result")
                .Select(result => 
                  new ScriptItem
                  {
                    Value = result.Attribute("Value").Value,
                    Action = result.Attribute("Action").Value
                  }
                )
                .ToList()
          }
        );
