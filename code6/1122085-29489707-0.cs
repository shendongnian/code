    public class StringToDoubleTypeConverter<T> : TypeConverter where T : IConvertible
    {
      // Other methods
      ...
      // Returns whether the type converter can convert an object from the specified type 
      // to the type of this converter.
      public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
      {
          return sourceType.GetInterface("IConvertible", false) != null;
      }
 
      // Returns whether the type converter can convert an object to the specified type.
      public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
      {
          return destinationType.GetInterface("IConvertible", false) != null;
      }
      public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
      {
          try
          {
              var convertible = (IConvertible)value;
              if (convertible != null) return convertible.ToType(typeof(T), culture);
          }
          catch (FormatException)
          {
              if (value != null && value.ToString().Equals("Small"))
              {
                  return MyConstants.Small;
              }
              throw;
          }
          return null;
      }
      // Converts the specified value object to the specified type.
      public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
      {
          return ((IConvertible)value).ToType(destinationType, culture);
      }
    }
