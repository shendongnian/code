    /// <summary>
    /// flags that a property of type enum is persisted with enum item's numerical value 
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Property)]
    public class NumericEnumAttribute : Attribute
    {
    }
    
    /// <summary>
    /// convention for the <see cref="NumericEnumAttribute"/> - ensures that the enum value is persisted as an integer
    /// </summary>
    public class NumericalEnumConvention : AttributePropertyConvention<NumericEnumAttribute>
    {
    	protected override void Apply(NumericEnumAttribute attribute, IPropertyInstance instance)
    	{
    		instance.CustomType(instance.Property.PropertyType);
    	}
    }
