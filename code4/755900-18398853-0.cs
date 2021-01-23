    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    
    static class Program
    {
        static void Main()
        {
            var obj = new CustomClass();
            Console.WriteLine(obj.Name);
    
            // show it working via XmlSerializer
            new XmlSerializer(obj.GetType()).Serialize(Console.Out, obj);
        }
    }
    public class CustomClass : EavBase
    {
        [EavInit(42, "name")]
        public uint Name
        {
            get { return GetEav(); }
            set { SetEav(value); }
        }
    }
    public abstract class EavBase
    {
        private Dictionary<string, uint> values;
        protected uint GetEav([CallerMemberName] string propertyName = null)
        {
            if (values == null) values = new Dictionary<string, uint>();
            uint value;
            if (!values.TryGetValue(propertyName, out value))
            {
                value = 0;
                var prop = GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    var attrib = (EavInitAttribute)Attribute.GetCustomAttribute(
                        prop, typeof(EavInitAttribute));
                    if (attrib != null)
                    {
                        value = attrib.DefaultValue;
                        if (!string.IsNullOrEmpty(attrib.Key))
                        {
                            value = LookupDefaultValueFromDatabase(attrib.Key);
                        }
                    }
                }
                values.Add(propertyName, value);
            }
            return value;
        }
        protected void SetEav(uint value, [CallerMemberName] string propertyName = null)
        {
            (values ?? (values = new Dictionary<string, uint>()))[propertyName] = value;
        }
        private static uint LookupDefaultValueFromDatabase(string key)
        {
            // TODO: real code here
            switch (key)
            {
                case "name":
                    return 7;
                default:
                    return 234;
            }
        }
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        protected class EavInitAttribute : Attribute
        {
            public uint DefaultValue { get; private set; }
            public string Key { get; private set; }
            public EavInitAttribute(uint defaultValue) : this(defaultValue, "") { }
            public EavInitAttribute(string key) : this(0, key) { }
            public EavInitAttribute(uint defaultValue, string key)
            {
                DefaultValue = defaultValue;
                Key = key ?? "";
            }
        }
    }
