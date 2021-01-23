    public class SomeDataFormatDeserializer
    {
        public static T Deserlize<T>(string str) where T : new()
        {
            var result = new T();
            var pattern = @"RSIQ~1~K0(?:~J(\w+=\d+))*";
            var match = Regex.Match(str, pattern);
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
               var attr = field.GetCustomAttribute(typeof(SomeDataFormatAttribute)) as SomeDataFormatAttribute;
               var capture = match.Groups[1].Captures
                                  .Cast<Capture>()
                                  .FirstOrDefault(c => c.Value.StartsWith(attr.Name));
               if (capture != null)
               {
                  var stringValue = capture.Value.Split('=').Last();
                  var value = Convert.ChangeType(stringValue, field.FieldType);
                  field.SetValue(result, value);
               }
            }                                     
            return result;
        }
    }
