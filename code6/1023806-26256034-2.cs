    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FriendlyNameAttribute : Attribute
    {
        public string FriendlyName { get; set; }
        public FriendlyNameAttribute(string friendlyName)
        {
            FriendlyName = friendlyName;
        }
    }
    public class ItemViewModel
    {
        private static readonly IDictionary<string, string> PropertyMap;
        static ItemViewModel()
        {
            PropertyMap = new Dictionary<string, string>();
            var myType = typeof (ItemViewModel);
            foreach (var propertyInfo in myType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (propertyInfo.GetGetMethod() != null)
                {
                    var attr = propertyInfo.GetCustomAttribute<FriendlyNameAttribute>();
                    if (attr == null)
                        continue;
                    PropertyMap.Add(attr.FriendlyName, propertyInfo.Name);
                }
            }
        }
        public static string GetPropertyMap(string groupingField)
        {
            string propName;
            
            PropertyMap.TryGetValue(groupingField, out propName);
            return propName; //will return null in case map not found.
        }
            
        [FriendlyName("problem_description")]
        public string ProblemDescription { get; set; }
        public string OtherProperty { get; set; } // will not be in map
    }
