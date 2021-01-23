    public static void SetValues(DTO dto, IEnumerable<IDto> items)
    {
        foreach (var x in items)
        {
            var propertyInfo = dto.GetType().GetProperty(x.ShortDescript,
                   BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
            if (propertyInfo != null)
            { 
                propertyInfo.SetValue(dto, x.ObjectValue);
            }
        }
    }
