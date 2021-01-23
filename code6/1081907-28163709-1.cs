    public static class ObjectConverter<T>
    {
        public static TTo Convert<TFrom, TTo>(TFrom value)
            where TFrom : T
            where TTo : T, new()
        {
            TTo result = new TTo(); // creates an instance of the target type
            var baseProperties = value.GetType().GetProperties() // gets all properties
                .Where(x => x.DeclaringType == typeof(T)); // based on target type
            foreach (var prop in baseProperties)
            {
                prop.SetValue(result, prop.GetValue(value)); // sets value to the target
            }
            return result;
        }
    }
