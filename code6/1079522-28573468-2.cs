    public static IEnumerable<DependencyProperty> GetDependencyProperties(this DependencyObject obj)
    {
        var propertyDescriptors = TypeDescriptor.GetProperties(obj, new Attribute[]
        {
            new PropertyFilterAttribute(PropertyFilterOptions.All)
        });
        return (from PropertyDescriptor pd in propertyDescriptors
                let dpd = DependencyPropertyDescriptor.FromProperty(pd)
                where dpd != null
                select dpd.DependencyProperty).ToList();
    }
    public static IEnumerable<DependencyProperty> GetUpdatedDependencyProperties(this DependencyObject obj)
    {
    	return (from property in obj.GetDependencyProperties().Where(x => !x.ReadOnly)
    			let metaData = property.GetMetadata(obj.GetType())
    			let defaultValue = metaData.DefaultValue
    			let currentValue = obj.GetValue(property)
    			where currentValue != defaultValue
    			select property).ToList();
    }
