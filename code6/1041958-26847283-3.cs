        writer.WriteStartArray();
        foreach (var employeeSalaryMappingDictionary in employeeSalaryMappingList)
        {
            writer.WriteStartObject();
                writer.WritePropertyName("ED");
                writer.WriteStartObject();
                foreach (var keyValuePair in employeeSalaryMappingDictionary)
                {
                    writer.WritePropertyName("ID-" + keyValuePair.Key);
                    serializer.Serialize(writer, keyValuePair.Value);
                }
                writer.WriteEndObject();
            writer.WriteEndObject();
        }
        writer.WriteEndArray();
