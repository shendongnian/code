    public static class Comparer
    {
        public static IConvertible CastToConvertible<T>(T value)
        {
            var en = value as Enum;
            if (en != null)
            {
                // convert enum to the base type 
                // (GetTypeCode() returns the base type)
                return (IConvertible) Convert.ChangeType(en, en.GetTypeCode());
            }
            if (value is IConvertible)
            {
                return value as IConvertible;
            }
            // we don't know how to compare other types between each other
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
                var convertedToFirst = (IConvertible)Convert.ChangeType(
                    secondConverted, firstConveted.GetTypeCode());
                return firstConveted.Equals(convertedToFirst);
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
