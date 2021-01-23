    public static List<object> ToModelViewObjectList(this IEnumerable<object> source, Type modelViewType)
    {
        List<object> destinationList = new List<object>();
    
        PropertyInfo[] ModelViewProperties = modelViewType.GetProperties();
        foreach (var sourceElement in source)
        {
            object destElement = Activator.CreateInstance(modelViewType);
            foreach (PropertyInfo sourceProperty in sourceElement.GetType().GetProperties())
            {
    
                if (ModelViewProperties.Select(m => m.Name).Contains(sourceProperty.Name))
                {
                    destElement.GetType().GetProperty(sourceProperty.Name).SetValue(destElement, sourceProperty.GetValue(sourceElement));
                }
            }
            destinationList.Add(destElement);
        }
    
        return destinationList;
    }
