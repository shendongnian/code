        internal static TypeConverter GetCoreConverterFromCustomType(Type type)
        {
            TypeConverter typeConverter = null;
            if (type.IsEnum)
            {
                // Need to handle Enums types specially as they require a ctor that
                // takes the underlying type.
                typeConverter = new System.ComponentModel.EnumConverter(type);
            }
            else if (typeof(Int32).IsAssignableFrom(type))
            {
                typeConverter = new System.ComponentModel.Int32Converter();
            }
            else if (typeof(Int16).IsAssignableFrom(type))
            {
                typeConverter = new System.ComponentModel.Int16Converter();
            }
            //...
