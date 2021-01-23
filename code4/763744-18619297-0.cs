    public class OracleCustomTypeMappingAttribute : Attribute
    {
        public OracleCustomTypeMappingAttribute(string typeName)
        {
            var schema = ConfigurationManager.AppSettings["Schema"];
            TypeMapping = schema + "." + typeName;
            // Or whatever property needs to be set
        }
    }
