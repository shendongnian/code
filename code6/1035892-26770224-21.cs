    var nextAttributeUpdates = rawAttributeUpdates
        .Skip(1)
        .Concat(new[] { new AttributeUpdate { Number = -1 } });
    AttributeUpdateViewModels = rawAttributeUpdates
        .Zip(
            nextAttributeUpdates, 
            (c, n) => new { Current = c, NextNumber = n.Number })
        .Select(
            x => new AttributeUpdateViewModel
            {
                Number = x.Current.Number,
                Attribute = x.Current.Attribute,
                New = x.Current.New,
                Old = x.Current.Old,
                IsLastInGroup = x.Current.Number != x.NextNumber
            })
        .ToList();
