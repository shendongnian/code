    public static bool ExceedsMaximumValue(object source, object destination)
    {
        Type sourceType = source.GetType();
        FieldInfo sourceMaxValue = sourceType.GetField("MaxValue");
        if (Object.ReferenceEquals(sourceMaxValue, null))
        {
            throw new ArgumentException("The source object type does not have a MaxValue field associated with it.");
        }
        Type destinationType = destination.GetType();
        FieldInfo destinationMaxValue = destinationType.GetField("MaxValue");
        if (Object.ReferenceEquals(destinationMaxValue, null))
        {
            throw new ArgumentException("The destination object type does not have a MaxValue field associated with it.");
        }
        object convertedSource;
        if (destinationType.IsAssignableFrom(sourceType))
        {
            convertedSource = source;
        }
        else
        {
            TypeConverter converter = TypeDescriptor.GetConverter(sourceType);
            if (converter.CanConvertTo(destinationType))
            {
                try
                {
                    convertedSource = converter.ConvertTo(source, destinationType);
                }
                catch (OverflowException)
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException("The source object type cannot be converted to the destination object type.");
            }
        }
        Type convertedSourceType = convertedSource.GetType();
        Type[] comparisonMethodParameterTypes = new Type[1]
        {
            destinationType
        };
        MethodInfo comparisonMethod = convertedSourceType.GetMethod("CompareTo", comparisonMethodParameterTypes);
        if (Object.ReferenceEquals(comparisonMethod, null))
        {
            throw new ArgumentException("The source object type does not have a CompareTo method.");
        }
        object[] comparisonMethodParameters = new object[1]
        {
            destination
        };
        int comparisonResult = (int)comparisonMethod.Invoke(convertedSource, comparisonMethodParameters);
        if (comparisonResult > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
