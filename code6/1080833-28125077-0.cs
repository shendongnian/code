    public class NamespaceMappingSerializationBinder : DefaultSerializationBinder
    {
        public string FromNamespace { get; set; }
        public string ToNamespace { get; set; }
        public override Type BindToType(string assemblyName, string typeName)
        {
            string fixedTypeName;
            if (FromNamespace != null && ToNamespace != null)
            {
                fixedTypeName = typeName.Replace(FromNamespace, ToNamespace);
            }
            else
            {
                fixedTypeName = typeName;
            }
            var type = base.BindToType(assemblyName, fixedTypeName);
            return type;
        }
    }
