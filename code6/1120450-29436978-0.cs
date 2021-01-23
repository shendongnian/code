    public abstract class RequestRootBase
    {
        [XmlIgnore]
        public abstract Type RequestType { get; }
        [XmlIgnore]
        public abstract Object RequestObject { get; }
    }
    public class RequestRoot<T> : RequestRootBase
    {
        public RequestRoot() { }
        public RequestRoot(T ActionNode) { this.ActionNode = ActionNode; }
        [XmlElement("Action")]
        public T ActionNode { get; set; }
        public override Type RequestType
        {
            get { return typeof(T); }
        }
        public override object RequestObject
        {
            get { return ActionNode; }
        }
    }
    public static class RequestRootHelper
    {
        public static RequestRootBase CreateBase(object action)
        {
            if (action == null)
                throw new ArgumentNullException();
            var type = action.GetType();
            return (RequestRootBase)Activator.CreateInstance(typeof(RequestRoot<>).MakeGenericType(type), new [] { action });
        }
        public static RequestRoot<T> Create<T>(T action)
        {
            return new RequestRoot<T> { ActionNode = action };
        }
    }
    public abstract class RequestRootXmlSerializerBase
    {
        const string RequestRootElementName = "RequestRoot";
        const string ActionElementName = "Action";
        const string TypeAttributeName = "Type";
        protected abstract Type BindToType(string name);
        protected abstract string BindToName(Type type);
        static string DefaultRootXmlElementNamespace(Type type)
        {
            var xmlType = type.GetCustomAttribute<XmlRootAttribute>();
            if (xmlType != null && !string.IsNullOrEmpty(xmlType.Namespace))
                return xmlType.Namespace;
            return null;
        }
        public void Serialize(RequestRootBase root, XmlWriter writer)
        {
            writer.WriteStartDocument();
            writer.WriteStartElement(RequestRootElementName);
            writer.WriteStartElement(ActionElementName);
            var typeName = BindToName(root.RequestType);
            writer.WriteAttributeString(TypeAttributeName, typeName);
            var serializer = new XmlSerializer(root.RequestType);
            var rootNameSpace = DefaultRootXmlElementNamespace(root.RequestType);
            var ns = new XmlSerializerNamespaces();
            if (string.IsNullOrEmpty(rootNameSpace))
                ns.Add("", "");
            else
                ns.Add("", rootNameSpace);
            serializer.Serialize(writer, root.RequestObject, ns);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
        public RequestRootBase Deserialize(XmlReader reader)
        {
            if (!reader.ReadToFollowing(RequestRootElementName))
                return null;
            if (!reader.ReadToFollowing(ActionElementName))
                return null;
            var typeName = reader[TypeAttributeName];
            if (typeName == null)
                return null;
            var type = BindToType(typeName);
            if (type == null)
                throw new InvalidDataException();  // THROW AN EXCEPTION in this case
            reader.ReadStartElement();
            var serializer = new XmlSerializer(type);
            var action = serializer.Deserialize(reader);
            if (action == null)
                return null;
            return RequestRootHelper.CreateBase(action);
        }
        public string SerializeToString(RequestRootBase root)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    Serialize(root, xmlWriter);
                return textWriter.ToString();
            }
        }
        public RequestRootBase DeserializeFromString(string xml)
        {
            using (var sr = new StringReader(xml))
            using (var xmlReader = XmlReader.Create(sr))
            {
                return Deserialize(xmlReader);
            }
        }
    }
    public class RequestRootXmlSerializer : RequestRootXmlSerializerBase
    {
        readonly Dictionary<string, Type> nameToType = new Dictionary<string, Type>();
        readonly Dictionary<Type, string> typeToName = new Dictionary<Type, string>();
        const string ListPrefix = "ArrayOf";
        const string ListPostFix = "";
        protected override string BindToName(Type type)
        {
            return typeToName[type];
        }
        protected override Type BindToType(string name)
        {
            return nameToType[name];
        }
        public RequestRootXmlSerializer(IEnumerable<Type> types)
        {
            if (types == null)
                throw new ArgumentNullException();
            foreach (var type in types)
            {
                if (type.IsInterface || type.IsAbstract)
                    throw new ArgumentException();
                var name = DefaultXmlElementName(type);
                nameToType.Add(name, type);
                typeToName.Add(type, name);
            }
        }
        static string DefaultXmlElementName(Type type)
        {
            if (type.IsGenericType
                && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                var elementType = type.GetGenericArguments()[0];
                return ListPrefix + DefaultXmlElementName(elementType) + ListPostFix;
            }
            else
            {
                var xmlRoot = type.GetCustomAttribute<XmlRootAttribute>();
                if (xmlRoot != null && !string.IsNullOrEmpty(xmlRoot.ElementName))
                    return xmlRoot.ElementName;
                var xmlType = type.GetCustomAttribute<XmlTypeAttribute>();
                if (xmlType != null && !string.IsNullOrEmpty(xmlType.TypeName))
                    return xmlType.TypeName;
                return type.Name;
            }
        }
    }
