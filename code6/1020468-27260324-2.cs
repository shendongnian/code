    public static class Comparer
    {
        public static IConvertible CastToConvertible<T>(T value)
        {
            if (value is IConvertible)
            {
                return (IConvertible)Convert.ChangeType(value, ((IConvertible)value).GetTypeCode());
            }
            // this type is not supported
            throw new ArgumentException("Unknown type: " + value.GetType());
        }
        public static bool Equals<T1, T2>(T1 first, T2 second)
        {
            try
            {
                IConvertible firstConveted = CastToConvertible(first);
                IConvertible secondConverted = CastToConvertible(second);
                // standard Equals cannot compare two different types,
                // so here the second value is
                // converted to the type of the first value
                var secondChangedType = (IConvertible)Convert.ChangeType(
                    secondConverted, firstConveted.GetTypeCode());
                return firstConveted.Equals(secondChangedType);
            }
            catch (Exception)
            {   
                // an exception might be caught in two cases:
                // 1. One of the values cannot be converted
                // to IConvertible interface.
                // 2. The second value cannot be converted 
                // to the type of the first value.
                return false;
            }
        }
    }
