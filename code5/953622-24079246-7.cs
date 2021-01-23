    public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
    {
        if( value.GetType() == typeof(string) )
        {
            // Parses the string to get the integer to set to the property.
            int newVal = int.Parse((string)value);
        
            // Tests whether new integer is already in the list.
            if( !values.Contains(newVal) )
            {
                // If the integer is not in list, adds it in order.
                values.Add(newVal);
                values.Sort();
            }                                
            // Returns the integer value to assign to the property.
            return newVal;
        }
        else
            return base.ConvertFrom(context, culture, value);
    }
