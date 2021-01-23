    public class SymitarInquiryDeserializer
    {
        /// <summary>
        /// Deserializes a string of J field key value pairs
        /// </summary>
        /// <param name="str">The request or response string</param>
        /// <param name="source">Optional: Use this if you are adding data to the source object</param>
        /// <param name="fieldName">Optional: Use this if you are only populating a single property and know what it is</param>
        /// <typeparam name="T">The target class type to populate</typeparam>
        /// <returns>New T Object or optional Source Object</returns>
        public static T DeserializeFieldJ<T>(string str, T source = null, string fieldName = null) where T : class, new() 
        {
            var result = source ?? new T();
    
            const string pattern = @"(?:~J(\w+=\d+))*";
            var match = Regex.Match(str, pattern);
    
            // Get fields of type T
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance).ToList();
    
            if (fieldName != null && fieldName.StartsWith("J")) fieldName = fieldName.Replace("J", "");
    
            if (!fieldName.IsNullOrEmpty())
            {
                var field = fields.FirstOrDefault(a => a.Name.Equals(fieldName, StringComparison.CurrentCultureIgnoreCase));
                var stringValue = GetValue(field, match);
                if (!stringValue.IsNullOrEmpty())
                    SetProperty(field, stringValue, result);
            }
            else
            {
                foreach (var field in fields)
                {
                    var stringValue = GetValue(field, match);
                    if(!stringValue.IsNullOrEmpty())
                        SetProperty(field, stringValue, result);
                }
            }
            return result;
        }
    
        private static string GetValue(FieldInfo field, Match match)
        {
            // Get out custom attribute of this field (might return null)
            var attr = field.GetCustomAttribute(typeof(SymitarInquiryDataFormatAttribute)) as SymitarInquiryDataFormatAttribute;
            if (attr == null) return null;
    
            // Find regex capture that starts with attributed name (might return null)
            var capture = match.Groups[1]
                                .Captures
                                .Cast<Capture>()
                                .FirstOrDefault(c => c.Value.StartsWith(attr.Name, StringComparison.CurrentCultureIgnoreCase));
            return capture == null ? null : capture.Value.Split('=').Last();
        }
    
        private static void SetProperty<T>(FieldInfo field, string stringValue, T result)
        {
            // Convert string to the proper type (like int)
    
            if (field.FieldType.FullName.Contains("Int32"))
                field.SetValue(result, stringValue.ParseInt(field.Name));
            else if (field.FieldType.FullName.Contains("Decimal"))
                field.SetValue(result, stringValue.ParseMoney(field.Name));
            else if (field.FieldType.FullName.Contains("DateTime"))
                field.SetValue(result, stringValue.ParseDate(field.Name));
            else
            {
                var value = Convert.ChangeType(stringValue, field.FieldType);
                field.SetValue(result, value);
            }
        }
    }
