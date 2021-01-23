    using System.Linq.Dynamic;
    ...
    
    var result = staticFields.AsQueryable().Select(dynamicFields.ToDynamicSelector())
                                           .Cast<DynamicClass>();
    
    foreach (var item in result)
    {
        Console.WriteLine(item.GetValue<string>(list[0]); // outputs all first names
    }
