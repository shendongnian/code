    public class Sex
    {
        public static readonly List<Sex> All = typeof(Sex).GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(Sex))
            .Select(f => (Sex)f.GetValue(null))
            .ToList();
        public static readonly Sex Female = new Sex("xx", "Female");
        public static readonly Sex Male = new Sex("xy", "Male");
        ...
    }
