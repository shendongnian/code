    private bool SetPropertyValue(JsonProperty property, ..., object target)
    {
        ...
        if (CalculatePropertyDetails(
              property, 
              ...,
              out useExistingValue,
              ... ))
        {
            return false;
        }
    
        ...
        if (propertyConverter != null && propertyConverter.CanRead)
        {
            ...
        }
        else
        {
            value = CreateValueInternal(
               ...,
               (useExistingValue) ? currentValue : null);
        }
    
        if ((!useExistingValue || value != currentValue)
            && ShouldSetPropertyValue(property, value))
        {
            property.ValueProvider.SetValue(target, value);
            ...    
            return true;
        }
        return useExistingValue;
    }
