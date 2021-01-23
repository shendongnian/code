        public static List<PropertyInfo> GetSearchProperties(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
           
            
            List<PropertyInfo> propL = new List<PropertyInfo>();
            foreach (var item in type.GetProperties())
            {
                object[] obj = item.GetCustomAttributes(typeof(Searchable), true);
                if (obj.Count() > 0)
                {
                    propL.Add(item);
                }
                else
                {                    
                    propL.AddRange(GetSearchPropertiesWithOrderBy(item.PropertyType));
                }
            }
            return propL;        
        }
        [System.AttributeUsage(System.AttributeTargets.Property)]
        public class Searchable : System.Attribute
        {
            
        }
        public class LookUpData
        {
            [Searchable]
            public string ManufactureName { get; set; }
        }
        public class Car
        {
            public int ID { get; set; }
            [Searchable]
            public string Model { get; set; }
            public int ManufactureId { get; set; }
            public LookUpData LookUpData { get; set; }
        }
