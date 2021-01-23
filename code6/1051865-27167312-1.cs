    public static class StringHelper
    {
        /// <summary>Trim all String properties of the given object</summary>
        public static TSelf TrimStringProperties<TSelf>(this TSelf input)
        {
    		if (input == null)
    			return input;
    			
            var stringProperties = typeof(TSelf).GetProperties()
                .Where(p => p.PropertyType == typeof(string));
    
            foreach (var stringProperty in stringProperties)
            {
                string currentValue = (string)stringProperty.GetValue(input, null);
                if (currentValue != null)
                    stringProperty.SetValue(input, currentValue.Trim(), null);
            }
            return input;
        }
    }
