    var rows = myContext.MyEntityCollection
        .Where(item => item.MyProperty != null)
        .AsEnumerable<MyEntity>()
        .Select(item => new 
            {
                Item = item,
                Parts = item.MyProperty.Split(new[] { ',' })
            })
        .Where(itemWithParts => itemWithParts.Parts.Contains("part3"))
        .Select(itemWithParts => itemWithParts.Item);
