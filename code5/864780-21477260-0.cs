    <#+
    string SortableBy(PropertyInfo property)
    {
        foreach (object attribute in property.GetCustomAttributes(true))
        {
            var sortable = attribute as SortableAttribute;
            if (sortable != null) return sortable.By == "" ? property.Name : sortable.By;
        }
        return property.Name;
    }
    #>
