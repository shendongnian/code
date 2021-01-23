    new DataContractSerializerSettings()
    {
        DataContractSurrogate = new EnumSurrogate(),
        KnownTypes = new Type[] { typeof(EnumValue<TestEnum>) }
    };
    public class EnumSurrogate : IDataContractSurrogate
    {
        #region IDataContractSurrogate Members
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }
        public Type GetDataContractType(Type type)
        {
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            IEnumValue enumValue = obj as IEnumValue;
            if (enumValue!= null)
            { return enumValue.Value; }
            return obj;
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj != null)
            {
                Type type = obj.GetType();
                if (type.IsEnum && Attribute.IsDefined(type, typeof(FlagsAttribute)))
                { return Activator.CreateInstance(typeof(EnumValue<>).MakeGenericType(type), obj); }
            }
            return obj;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }
        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return null;
        }
        #endregion
    }
    public interface IEnumValue : IXmlSerializable
    {
        object Value { get; }
    }
    [Serializable]
    public class EnumValue<T> : IEnumValue
        where T : struct
    {
        #region Fields
        private T value;
        #endregion
        #region Constructors
        public EnumValue()
        {
        }
        public EnumValue(T value)
        {
            this.value = value;
        }
        #endregion
        #region IXmlSerializable Members
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            if (reader.MoveToAttribute("Value"))
            { value = /* Your implementation here */; }
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartAttribute("Value");
            // Your implementation here
            writer.WriteEndAttribute();
        }
        #endregion
        #region IEnumValue Members
        public object Value
        {
            get { return value; }
        }
        #endregion
    }
