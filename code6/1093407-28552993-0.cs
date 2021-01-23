    private IEnumerable<T> Deserialize<T>(IList<string[]> rows, object index)
        where T : new()
    {
        Type indexType = index.GetType();
        IList<PropertyInfo> indexProperties = indexType.GetProperties();
        var dtoType = typeof(T);
        IList<PropertyInfo> dtoProperties = dtoType.GetProperties();
        var setters = new List<Tuple<int,PropertyInfo>>();
        foreach (var dtoProperty in dtoProperties)
        {
            var indexProperty = indexType.GetProperty(dtoProperty.Name);
            var columnIndex = (int) indexProperty.GetValue(index);
            setters.Add(Tuple.Create(columnIndex, dtoProperty));
        }
        foreach (var row in rows)
        {
            var dto = new T();
            foreach (var pair in setters)
            {
                var colIndex = pair.Item1;
                var prop = pair.Item2;
                prop.SetValue(dto, row[colIndex]);
            }
            yield return dto;
        }
    }
