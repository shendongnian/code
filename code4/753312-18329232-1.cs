    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    class EnumDescriptor : Attribute
    {
        public readonly string Description;
        public EnumDescriptor(string description)
        {
            this.Description = description;
        }
        public static string GetFromValue<T>(T value) where T : struct
        {
            var type = typeof(T);
            var memInfo = type.GetField(value.ToString());
            var attributes = memInfo.GetCustomAttributes(typeof(EnumDescriptor), false);
            if (attributes.Length == 0)
            {
                return null;
            }
            return ((EnumDescriptor)attributes[0]).Description;
        }
    }
    enum MyEnum
    {
        [EnumDescriptor("Hello")]
        aaaVal1,
        aaaVal2,
        aaaVal3,
    }  
    string translate(MyEnum myEnum)
    {
        // The ?? operator returns the left value unless the lv is null,
        // if it's null it returns the right value.
        string result = EnumDescriptor.GetFromValue(myEnum) ?? "fsdfds";
        return result;
    }
