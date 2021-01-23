    public static class EnitityFrameworkHelper
        {
            public static void SetValuesByReflection(this DbPropertyValues propertyValues, object o, IEnumerable<string> properties = null)
            {
                var reflProperties = o.GetType().GetProperties();
                var prop = properties ?? propertyValues.PropertyNames;
                foreach (var p in prop)
                {
                    var refp = reflProperties.First(x => x.Name == p);
                    var v= refp.GetValue(o);
                    propertyValues[p] = v;
                }
            }
        }
