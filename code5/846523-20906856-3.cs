    private static void AddPrimitive(Type type, string dataTypeName, string formatterName, TypeFlags flags)
        {
            XmlSchemaSimpleType dataType = new XmlSchemaSimpleType {
                Name = dataTypeName
            };
            TypeDesc desc = new TypeDesc(type, true, dataType, formatterName, flags);
            if (primitiveTypes[type] == null)
            {
                primitiveTypes.Add(type, desc);
            }
            primitiveDataTypes.Add(dataType, desc);
            primitiveNames.Add(dataTypeName, "http://www.w3.org/2001/XMLSchema", desc);
        }
