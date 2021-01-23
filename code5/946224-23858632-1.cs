    [AttributeUsage(AttributeTargets.Field)]
    public class GuidValue : Attribute
    {
        public Guid Guid
        {
            get;
            private set;
        }
        public GuidValue(Guid guid)
        {
            this.Guid = guid;
        }
        public GuidValue(string stringGuid)
        {
            this.Guid = new Guid(stringGuid);
        }
    }
    public static class GuidBackedEnums
    {
        private static Guid GetGuid(Type type, string name)
        {
            return type.GetField(name).GetCustomAttribute<GuidValue>().Guid;
        }
        public static Guid GetGuid(Enum enumValue)
        {
            Type type = enumValue.GetType();
            if (!type.IsEnum)
                throw new Exception();
            return GetGuid(type, enumValue.ToString());
        }
        public static T CreateFromGuid<T>(Guid guid)
        {
            Type type = typeof(T);
            if (!type.IsEnum)
                throw new Exception();
            foreach (var value in Enum.GetValues(type))
            {
                if (guid == GetGuid(type, value.ToString()))
                    return (T)value;
            }
            throw new Exception();
        }
    }
