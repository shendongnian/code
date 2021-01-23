    static class SerializationHelper
    {
        public static string GetAutoPropertyName(string baseTypeName, string name)
        {
            return baseTypeName + "+<" + name + ">k__BackingField";
        }
        public static string GetAutoPropertyName(string name)
        {
            return "<" + name + ">k__BackingField";
        }
    }
    [Serializable]
    class v2base : ISerializable
    {
        protected v2base(
            SerializationInfo info,
            StreamingContext context)
        {
            a = info.GetInt32(SerializationHelper.GetAutoPropertyName("v1base", "a"));
            b = info.GetInt32(SerializationHelper.GetAutoPropertyName("v1base", "b"));
        }
        public int a { get; set; }
        public int b { get; set; }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(SerializationHelper.GetAutoPropertyName("v1base", "a"), a);
            info.AddValue(SerializationHelper.GetAutoPropertyName("v1base", "b"), b);
        }
    }
    [Serializable]
    class v2derived : v2base
    {
        protected v2derived(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
            c = info.GetInt32(SerializationHelper.GetAutoPropertyName("c"));
            d = info.GetInt32(SerializationHelper.GetAutoPropertyName("d"));
        }
        public int c { get; set; }
        public int d { get; set; }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(SerializationHelper.GetAutoPropertyName("c"), c);
            info.AddValue(SerializationHelper.GetAutoPropertyName("c"), d);
        }
    }
