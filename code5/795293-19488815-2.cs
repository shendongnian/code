    public static List<Tuple<PropertyInfo, string>> GetSearchPropertiesWithOrderBy(Type type)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        return type
            .GetProperties()
            .Select(
                x =>
                {
                    var searchableAttribute = GetNestedSearchableAttribute(x);
                    var description = new
                    {
                        Property = x,
                        Attribute = searchableAttribute,
                        Name = searchableAttribute == null ? x.Name : searchableAttribute.SearchablePropertyName
                    };
                    return description;
                })
            .OrderBy(x => x.Attribute != null ? x.Attribute.OrderBy : 200)
            .Select(x => Tuple.Create(x.Property, x.Name))
            .ToList();
    }
