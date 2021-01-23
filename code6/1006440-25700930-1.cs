    using System.Linq.Dynamic;
    // ..
    var columns = new[] { "col1", "col2", etc };
    
    var result = context.Files.OrderBy(file => file.Id)
                              .Select(columns.ToDynamicSelector())
                              .Cast<DynamicClass>.ToList();
