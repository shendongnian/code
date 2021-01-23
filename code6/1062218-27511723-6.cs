    public class SomeDataFormatDeserializer
    {
        public static T Deserlize<T>(string str) where T : new()
        {
            var result = new T();
            var pattern = @"RSIQ~1~K0(?:~J(\w+=\d+))*";
            var match = Regex.Match(str, pattern);
            // Get fields of type T
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
               // Get out custom attribute of this field (might return null)
               var attr = field.GetCustomAttribute(typeof(SomeDataFormatAttribute)) as SomeDataFormatAttribute;
               // Find regex capture that starts with attributed name (might return null)
               var capture = match.Groups[1].Captures
                                  .Cast<Capture>()
                                  .FirstOrDefault(c => c.Value.StartsWith(attr.Name));
               if (capture != null)
               {
                  var stringValue = capture.Value.Split('=').Last();
                  // Convert string to the proper type (like int)
                  var value = Convert.ChangeType(stringValue, field.FieldType);
                  field.SetValue(result, value);
               }
            }                                     
            return result;
        }
    }
