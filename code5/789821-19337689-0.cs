    public class StackOverflow_19336832
    {
        public class RequiredAttribute : Attribute
        {
            public string ErrorMessage { get; set; }
        }
        public class Person
        {
            public int ID { get; set; }
            [Required(ErrorMessage = "Name is required.")]
            public string Name { get; set; }
            public DateTime Birthday { get; set; }
            public bool IsMarried { get; set; }
        }
        static JObject GetSchema(Type type)
        {
            var result = new JObject();
            foreach (var prop in type.GetProperties())
            {
                var name = prop.Name;
                var propType = prop.PropertyType;
                var field = new JObject();
                result.Add(name, field);
                switch (Type.GetTypeCode(propType))
                {
                    case TypeCode.Boolean:
                        field.Add("type", "bool");
                        break;
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                    case TypeCode.Double:
                    case TypeCode.Single:
                        field.Add("type", "number");
                        break;
                    case TypeCode.String:
                        field.Add("type", "string");
                        break;
                    case TypeCode.DateTime:
                        field.Add("type", "date");
                        break;
                    default:
                        throw new ArgumentException("Don't know how to generate schema for property with type " + propType.FullName);
                }
                var req = prop.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault() as RequiredAttribute;
                if (req != null)
                {
                    var validation = new JObject();
                    field.Add("validation", validation);
                    validation.Add("required", true);
                    if (!string.IsNullOrEmpty(req.ErrorMessage))
                    {
                        validation.Add("message", req.ErrorMessage);
                    }
                }
            }
            return result;
        }
        public static void Test()
        {
            var schema = GetSchema(typeof(Person));
            Console.WriteLine(schema);
        }
    }
