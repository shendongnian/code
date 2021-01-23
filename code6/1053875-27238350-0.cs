    public static class CsvUtility
    {
        // I'm varying this a bit because I think you should still work at
        // understanding the code before copy-pasting. But the basic premise
        // is as follows:
        public static String CreateFromEnumerable(IEnumerable enumerable)
        {
            // create (and store) a reference to your builder. This should
            // be passed around instead of creating one-off instances within
            // each method.
            var sb = new StringBuilder();
            var i = 0; // counter
            
            // Iterate over each object
            IEnumerator enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                // Crab current object from enumerator
                var obj = enumerator.Current;
                
                // Cache the list of properties
                var properties = obj.GetType().GetProperties();
                if (i++ == 0)
                {
                    // if its the first item, use the properties list and
                    // output the heading column.
                    // Notice how the builder is passed as an argument.
                    AddHeading(sb, properties);
                }
                
                // every item will them be dumped as usual.
                // Notice how the builder is passed as an argument.
                AddData(sb, properties, obj);
            }
            
            // Return the final result as a string
            return sb.ToString();
        }
        
        // Build a heading from the properties of the object
        private static void AddHeading(StringBuilder sb, PropertyInfo[] properties)
        {
            // quick short-circuit check
            if (properties == null || properties.Length == 0) return;
            
            // iterate over the properties
            for (var p = 0; p < properties.Length; p++)
            {
                // if it's not the first property add a comma
                if (p > 0)
                {
                    sb.Append(",");
                }
                // add the property name, escaping as necessary
                sb.Append(EscapeValue(properties[p].Name));
            }
            
            // add a new line (this line is complete)
            sb.AppendLine();
        }
        
        // Build a line based on the properties and the object itself
        private static void AddData(StringBuilder sb, PropertyInfo[] properties, Object obj)
        {
            // quick short-circuit check
            if (properties == null || properties.Length == 0) return;
            if (Object.ReferenceEquals(obj, null)) return;
            
            // iterate over the properties
            for (var p = 0; p < properties.Length; p++)
            {
                // if it's not the first property add a comma
                if (p > 0)
                {
                    sb.Append(",");
                }
                
                // Get the value of the property from the original object
                // Also, convert it to a string so we can work with it.
                var val = properties[p].GetValue(obj).ToString();
                
                // add the value, escaping as necessary
                sb.Append(EscapeValue(val));
            }
            
            // add a new line (this line is complete)
            sb.AppendLine();
        }
        
        // Escape the value when necessary (per CSV standards)
        private static String EscapeValue(String value)
        {
            // quick short-circuit check
            if (String.IsNullOrEmpty(value)) return String.Empty;
            
            // If the value has a comma or a quote, we need to:
            // 1. Wrap the value in quotations
            // 2. Convert any existing quotations to double-quotations
            if (value.IndexOf(',') > -1 || value.IndexOf('"') > -1)
            {
                return String.Concat("\"", value.Replace("\"", "\"\""), "\"");
            }
            
            // No modification needed--return as-is.
            return value;
        }
    }
