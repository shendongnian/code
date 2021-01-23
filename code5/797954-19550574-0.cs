    public enum PackageType
    {
        LOGIN_AUTH = 23,
        // More enum members here
    }
    class Package
    {
        public int Id { get; set; }
        public PackageType Type { get { return (PackageType) Id; }}
    }
    class SomeClass
    {
        IDictionary<PackageType, Action<Type>> _dictionaryPacketHandlers = new Dictionary<PackageType, Action<Type>>()
        {
            {PackageType.LOGIN_AUTH, package => { /* Logic here */ }},
            // More handlers here
        };
    }
