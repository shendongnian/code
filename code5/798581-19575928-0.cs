    using System.Data.Linq.Mapping;
    ...
    ...
    var columnNames = typeof(Building)
                        .GetProperties()
                        .Where(p => p.GetCustomAttributes(typeof(ColumnAttribute), false).Any())
                        .Select(p => p.Name)
                        .ToList();
