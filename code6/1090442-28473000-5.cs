    public class XmlPolymorphicList<T> : List<T>, IXmlSerializable where T : class
    {
        static XmlPolymorphicList()
        {
            // Make sure the scope of objects to find isn't *EVERYTHING*
            if (typeof(T) == typeof(object))
            {
                throw new InvalidOperationException("Cannot create a XmlPolymorphicList<object>");
            }
        }
        internal sealed class DerivedTypeDictionary
        {
            Dictionary<Type, string> derivedTypeNames;
            Dictionary<string, Type> derivedTypes;
            DerivedTypeDictionary()
            {
                derivedTypeNames = typeof(T).DerivedTypes().ToDictionary(t => t, t => t.DefaultXmlElementName());
                derivedTypes = derivedTypeNames.ToDictionary(p => p.Value, p => p.Key); // Will throw an exception if names are not unique
            }
            public static DerivedTypeDictionary Instance { get { return Singleton<DerivedTypeDictionary>.Instance; } }
            public string GetName(Type type)
            {
                return derivedTypeNames[type];
            }
            public Type GetType(string name)
            {
                return derivedTypes[name];
            }
        }
        public XmlPolymorphicList()
            : base()
        {
        }
        public XmlPolymorphicList(IEnumerable<T> items)
            : base(items)
        {
        }
        #region IXmlSerializable Members
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            while (reader.NodeType == XmlNodeType.Element)
            {
                var name = reader.Name;
                var type = DerivedTypeDictionary.Instance.GetType(name);
                var item = (T)(new XmlSerializer(type).Deserialize(reader));
                if (item != null)
                    Add(item);
            }
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            foreach (var item in this)
            {
                new XmlSerializer(item.GetType()).Serialize(writer, item);
            }
        }
        #endregion
    }
    public static class XmlSerializationHelper
    {
        public static string DefaultXmlElementName(this Type type)
        {
            var xmlType = type.GetCustomAttribute<XmlTypeAttribute>();
            if (xmlType != null && !string.IsNullOrEmpty(xmlType.TypeName))
                return xmlType.TypeName;
            return type.Name;
        }
    }
    public class Singleton<T> where T : class
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton()
        {
        }
        /// <summary>
        /// Private nested class which acts as singleton class instantiator. This class should not be accessible outside <see cref="Singleton<T>"/>
        /// </summary>
        class Nested
        {
            /// <summary>
            /// Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            /// </summary>
            static Nested()
            {
            }
            /// <summary>
            /// Static instance variable
            /// </summary>
            internal static readonly T instance = (T)Activator.CreateInstance(typeof(T), true);
        }
        public static T Instance { get { return Nested.instance; } }
    }
