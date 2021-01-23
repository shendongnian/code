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
        private Enum value;
        private static Type enumType;
        private static long[] values;
        private static string[] names;
        private static bool isULong;
        #endregion
        #region Constructors
        static EnumValue()
        {
            enumType = typeof(T);
            if (!enumType.IsEnum)
            { throw new InvalidOperationException(); }
            FieldInfo[] fieldInfos = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
            values = new long[fieldInfos.Length];
            names = new string[fieldInfos.Length];
            isULong = Enum.GetUnderlyingType(enumType) == typeof(ulong);
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                FieldInfo fieldInfo = fieldInfos[i];
                EnumMemberAttribute enumMemberAttribute = (EnumMemberAttribute)fieldInfo
                    .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                    .FirstOrDefault();
                IConvertible value = (IConvertible)fieldInfo.GetValue(null);
                values[i] = (isULong)
                    ? (long)value.ToUInt64(null)
                    : value.ToInt64(null);
                names[i] = (enumMemberAttribute == null || string.IsNullOrEmpty(enumMemberAttribute.Value))
                    ? fieldInfo.Name
                    : enumMemberAttribute.Value;
            }
        }
        public EnumValue()
        {
        }
        public EnumValue(Enum value)
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
            string stringValue = reader.ReadElementContentAsString();
            long longValue = 0;
            int i = 0;
            // Skip initial spaces
            for (; i < stringValue.Length && stringValue[i] == ' '; i++) ;
            // Read comma-delimited values
            int startIndex = i;
            int nonSpaceIndex = i;
            int count = 0;
            for (; i < stringValue.Length; i++)
            {
                if (stringValue[i] == ',')
                {
                    count = nonSpaceIndex - startIndex;
                    if (count > 0)
                    { longValue |= ReadEnumValue(stringValue, startIndex, count); }
                    nonSpaceIndex = ++i;
                    // Skip spaces
                    for (; i < stringValue.Length && stringValue[i] == ' '; i++) ;
                    startIndex = i;
                    if (i == stringValue.Length)
                    { break; }
                }
                else
                {
                    if(stringValue[i] != ' ')
                    { nonSpaceIndex++; }
                }
            }
            count = i - startIndex;
            if (count > 0)
                longValue |= ReadEnumValue(stringValue, startIndex, count);
            value = (isULong)
                ? (Enum)Enum.ToObject(enumType, (ulong)longValue)
                : (Enum)Enum.ToObject(enumType, longValue);
        }
        public void WriteXml(XmlWriter writer)
        {
            long longValue = (isULong)
                ? (long)((IConvertible)value).ToUInt64(null)
                : ((IConvertible)value).ToInt64(null);
            int zeroIndex = -1;
            bool noneWritten = true;
            for (int i = 0; i < values.Length; i++)
            {
                long current = values[i];
                if (current == 0)
                {
                    zeroIndex = i;
                    continue;
                }
                if (longValue == 0)
                { break; }
                if ((current & longValue) == current)
                {
                    if (noneWritten)
                    { noneWritten = false; }
                    else
                    { writer.WriteString(","); }
                    writer.WriteString(names[i]);
                    longValue &= ~current;
                }
            }
            if (longValue != 0)
            { throw new InvalidOperationException(); }
            if (noneWritten && zeroIndex >= 0)
            { writer.WriteString(names[zeroIndex]); }
        }
        #endregion
        #region IEnumValue Members
        public object Value
        {
            get { return value; }
        }
        #endregion
        #region Private Methods
        private static long ReadEnumValue(string value, int index, int count)
        {
            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                if (string.CompareOrdinal(value, index, name, 0, count) == 0)
                { return values[i]; }
            }
            throw new InvalidOperationException();
        }
        #endregion
    }
