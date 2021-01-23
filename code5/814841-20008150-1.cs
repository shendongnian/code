    [AttributeUsage(AttributeTargets.Field)]
    public sealed class EnumDisplayNameAttribute : Attribute
    {
        public readonly string Displayname;
        public EnumDisplayNameAttribute(string displayname)
        {
            Displayname = displayname;
        }
        public static EnumDisplayNameAttribute Get<T>(T item)
        {
            FieldInfo member = typeof(T).GetField(item.ToString());
            if (member == null)
                return null;
            object[] attrs = member.GetCustomAttributes(typeof(EnumDisplayNameAttribute), true);
            return attrs.Length == 0 ? null : attrs[0] as EnumDisplayNameAttribute;
        }
    }
    enum SizeType : int
    {
        [EnumDisplayName("10%")]
        Height_10_Pct = 40,
        [EnumDisplayName("20%")]
        Height_20_Pct = 80,
        [EnumDisplayName("30%")]
        Height_30_Pct = 120,
        [EnumDisplayName("40%")]
        Height_40_Pct = 160,
        [EnumDisplayName("50%")]
        Height_50_Pct = 200,
        [EnumDisplayName("60%")]
        Height_60_Pct = 240,
        [EnumDisplayName("70%")]
        Height_70_Pct = 280,
        [EnumDisplayName("80%")]
        Height_80_Pct = 320,
        [EnumDisplayName("90%")]
        Height_90_Pct = 360,
        [EnumDisplayName("100%")]
        Height_100_Pct = 400
    }
    public static Dictionary<string, int> ThumbSizeOptions = new Dictionary<string, int>(BuildThumbSizeOptions());
    public static Dictionary<string, int> BuildThumbSizeOptions()
    {
        ThumbSizeOptions = new Dictionary<string, int>();
        foreach (SizeType val in Enum.GetValues(typeof(SizeType)))
        {
            ThumbSizeOptions.Add(EnumDisplayNameAttribute.Get(val).Displayname, (int)val);
        }
        return ThumbSizeOptions;
    }
