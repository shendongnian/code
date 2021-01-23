    public virtual void ResetValues()
    {
        foreach (var property in TypeDescriptor.GetProperties(typeof(TAttributedType)).Cast<PropertyDescriptor>())
		{
			var defaultValueAttribute = (DefaultValueAttribute)property.Attributes[typeof(DefaultValueAttribute)];
			var typeConverterAttribute = (TypeConverterAttribute)property.Attributes[typeof(TypeConverterAttribute)];
			if (defaultValueAttribute != null && defaultValueAttribute.Value is string &&
				typeConverterAttribute != null && !string.IsNullOrWhiteSpace(typeConverterAttribute.ConverterTypeName))
			{
				var typeConverterType = Type.GetType(typeConverterAttribute.ConverterTypeName);
				if (typeConverterType != null)
				{
					var typeConverter = (TypeConverter)Activator.CreateInstance(typeConverterType);
					if (typeConverter.CanConvertFrom(typeof(string)))
					{
						var propertyValue = typeConverter.ConvertFrom(defaultValueAttribute.Value);
						if (propertyValue != null)
						{
							property.SetValue(this, propertyValue);
							continue;
						}
					}
				}
			}
			if (property.CanResetValue(this))
			{
				property.ResetValue(this);
			}
		}
	}
