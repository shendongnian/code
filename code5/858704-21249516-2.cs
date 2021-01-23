    public static class FixedLengthFormatter
    {
        public static T ParseString<T>(string inputString)
        {
            Type tType = typeof(T);
            var properties = tType.GetProperties(BindingFlags.Instance | BindingFlags.Public); //;.Where(x => x.GetCustomAttributes(typeof(FixedLengthDelimeterAttribute), false).Count() > 0);
    
            T newT = (T)Activator.CreateInstance(tType);
    
            Dictionary<PropertyInfo, FixedLengthDelimeterAttribute> dictionary = new Dictionary<PropertyInfo, FixedLengthDelimeterAttribute>();
            foreach (var property in properties)
            {
                var atts = property.GetCustomAttributes(typeof(FixedLengthDelimeterAttribute), false);
                if (atts.Length == 0)
                    continue;
                dictionary[property] = atts[0] as FixedLengthDelimeterAttribute;
            }
            List<string> stringPieces = new List<string>();
            foreach (var kvp in dictionary.OrderBy(x => x.Value.OrderNumber))
            {
                int length = kvp.Value.FixedLength;
                if (inputString.Length < length)
                    throw new Exception("error on attribute order number:" + kvp.Value.OrderNumber + " the string is too short.");
                string piece = inputString.Substring(0, length);
                inputString = inputString.Substring(length);
                kvp.Key.SetValue(newT, piece.Trim(), null);
            }
            return newT;
        }
    }
