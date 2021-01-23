    var q = items
        .GroupBy(x => new { x.Id, x.Value})
        .Select(group => new 
                 {
                     Id = group.Key.Id, 
                     Green = group.Any(item => item.Color == "Green"), 
                     Red = group.Any(item => item.Color == "Red"),
                     Value = group.Key.Value,
                 });
