    public interface IHasElementName
    {
        string ElementName { get; set; }
    }
    public class XmlNamedElementList<T> : List<T>, IXmlSerializable where T : IHasXmlElementName
    {
        // https://msdn.microsoft.com/en-us/library/System.Xml.Serialization.XmlSerializer%28v=vs.110%29.aspx
        // Any serializer created with the "XmlSerializer(typeof(T), rootAttribute)" must be cached
        // to avoid resource & memory leaks.
        class ValueSerializerCache
        {
            // By using a nested class with a static constructor, we defer generation of the XmlSerializer until it's actually required.
            static ValueSerializerCache()
            {
                var rootAttribute = new XmlRootAttribute();
                rootAttribute.ElementName = ValueTypeName;
                rootAttribute.Namespace = ValueTypeNamespace;
                serializer = new XmlSerializer(typeof(T), rootAttribute);
            }
            static readonly XmlSerializer serializer;
            internal static XmlSerializer Serializer { get { return serializer; } }
        }
        static string ValueTypeName { get { return typeof(T).DefaultXmlElementName(); } }
        static string ValueTypeNamespace { get { return typeof(T).DefaultXmlElementNamespace(); } }
        #region IXmlSerializable Members
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var typeName = ValueTypeName;
            reader.ReadStartElement(); // Advance to the first sub element of the list element.
            while (reader.NodeType == XmlNodeType.Element)
            {
                bool isEmpty = reader.IsEmptyElement;
                var name = reader.Name;
                using (var subReader = reader.ReadSubtree())
                {
                    var doc = XDocument.Load(subReader);
                    if (doc != null && doc.Root != null)
                    {
                        doc.Root.Name = doc.Root.Name.Namespace + typeName;
                        using (var docReader = doc.CreateReader())
                        {
                            var obj = ValueSerializerCache.Serializer.Deserialize(docReader);
                            if (obj != null)
                            {
                                T value = (T)obj;
                                value.ElementName = XmlConvert.DecodeName(name);
                                Add(value);
                            }
                        }
                    }
                }
                // Move past the XmlNodeType.Element
                if (reader.IsEmptyElement && reader.NodeType == XmlNodeType.Element)
                    reader.Read();
                else if (reader.NodeType == XmlNodeType.EndElement)
                    reader.ReadEndElement();
            }
            // Consume the end of the list element also.
            if (reader.NodeType == XmlNodeType.EndElement)
                reader.ReadEndElement();
        }
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            foreach (var value in this)
            {
                XDocument doc = new XDocument();
                using (var subWriter = doc.CreateWriter())
                {
                    // write xml into the writer
                    ValueSerializerCache.Serializer.Serialize(subWriter, value);
                }
                if (doc.Root == null)
                    continue;
                doc.Root.Name = doc.Root.Name.Namespace + XmlConvert.EncodeName(value.ElementName);
                // Remove redundant namespaces.
                foreach (var attr in doc.Root.Attributes().ToList())
                {
                    if (!attr.IsNamespaceDeclaration || string.IsNullOrEmpty(attr.Value))
                        continue;
                    var prefix = writer.LookupPrefix(attr.Value);
                    if ((prefix == attr.Name.LocalName)
                        || (prefix == string.Empty && attr.Name == "xmlns"))
                        attr.Remove();
                }
                doc.Root.WriteTo(writer);
            }
        }
        #endregion
    }
    public static class XmlSerializationHelper
    {
        static Attribute GetCustomAttribute(MemberInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }
        static T GetCustomAttribute<T>(MemberInfo element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }
        public static string DefaultXmlElementName(this Type type)
        {
            var xmlType = GetCustomAttribute<XmlTypeAttribute>(type);
            if (xmlType != null && !string.IsNullOrEmpty(xmlType.TypeName))
                return xmlType.TypeName;
            var xmlRoot = GetCustomAttribute<XmlRootAttribute>(type);
            if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.ElementName))
                return xmlRoot.ElementName;
            return type.Name;
        }
        public static string DefaultXmlElementNamespace(this Type type)
        {
            var xmlType = GetCustomAttribute<XmlTypeAttribute>(type);
            if (xmlType != null && !string.IsNullOrEmpty(xmlType.Namespace))
                return xmlType.Namespace;
            var xmlRoot = GetCustomAttribute<XmlRootAttribute>(type);
            if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.Namespace))
                return xmlRoot.Namespace;
            return string.Empty;
        }
        public static string GetXml<T>(this T obj)
        {
            return GetXml(obj, false);
        }
        public static string GetXml<T>(this T obj, bool omitNamespace)
        {
            return GetXml(obj, new XmlSerializer(obj.GetType()), omitNamespace);
        }
        public static string GetXml<T>(this T obj, XmlSerializer serializer)
        {
            return GetXml(obj, serializer, false);
        }
        public static string GetXml<T>(T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            XmlSerializerNamespaces ns = null;
            if (omitStandardNamespaces)
            {
                ns = new XmlSerializerNamespaces();
                ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            }
            return GetXml(obj, serializer, ns);
        }
        public static string GetXml<T>(T obj, XmlSerializerNamespaces ns)
        {
            return GetXml(obj, new XmlSerializer(obj.GetType()), ns);
        }
        public static string GetXml<T>(T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {
            using (var textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;        // For cosmetic purposes.
                settings.IndentChars = "    "; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    if (ns != null)
                        serializer.Serialize(xmlWriter, obj, ns);
                    else
                        serializer.Serialize(xmlWriter, obj);
                }
                return textWriter.ToString();
            }
        }
    }
