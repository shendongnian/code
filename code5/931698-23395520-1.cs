    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FilterNameAttribute : Attribute
    {
        public FilterNameAttribute(string filterName)
        {
            FilterName = filterName;
        }
        public string FilterName { get; private set; }
    }
    [FilterName("MyFilterName")]
    public class MyFilter
    {
        //Do whatever you want here
    }
    public static class FilterHelper
    {
        static Dictionary<string, Type> _filterTypesDict;
        static FilterHelper()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _filterTypesDict = assembly.GetTypes()
                .Select(type => new { type, attrib = (FilterNameAttribute)type.GetCustomAttributes(typeof(FilterNameAttribute), false).FirstOrDefault() })
                .Where(x => x.attrib != null)
                .ToDictionary(x => x.attrib.FilterName, x => x.type);
        }
        public static Type GetFilterType(string filterName)
        {
            Type filterType;
            if (!_filterTypesDict.TryGetValue(filterName, out filterType))
            {
                throw new Exception("Unknown Filter Name.");
            }
            return filterType;
        }
        public static object GetFilter(string filterName)
        {
            return Activator.CreateInstance(GetFilterType(filterName));
        }
    }
