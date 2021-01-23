    public sealed class SkipStreamSurrogate : IDataContractSurrogate
    {
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
            return obj;
        }
        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
        {
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            // Skip serialization of a System.Stream
            if (obj is Stream)
            { return null; }
            return obj;
        }
        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }
        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return typeDeclaration;
        }
    }
