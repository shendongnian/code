    public class StructBsonSerializer : IBsonSerializer 
    { 
        public void Serialize(BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options) 
        { 
    		var fields = nominalType.GetFields(BindingFlags.Instance | BindingFlags.Public); 
            var propsAll = nominalType.GetProperties(BindingFlags.Instance | BindingFlags.Public); 
    
            var props = new List<PropertyInfo>(); 
            foreach (var prop in propsAll) 
            { 
                if (prop.CanWrite) 
                { 
                    props.Add(prop); 
                } 
            } 
    
            bsonWriter.WriteStartDocument(); 
    
            foreach (var field in fields) 
            { 
                bsonWriter.WriteName(field.Name); 
                BsonSerializer.Serialize(bsonWriter, field.FieldType, field.GetValue(value)); 
            } 
            foreach (var prop in props) 
            { 
                bsonWriter.WriteName(prop.Name); 
                BsonSerializer.Serialize(bsonWriter, prop.PropertyType, prop.GetValue(value, null)); 
            } 
    
            bsonWriter.WriteEndDocument(); 
        } 
    
        public object Deserialize(BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options) 
        { 
            var obj = Activator.CreateInstance(actualType); 
    
            bsonReader.ReadStartDocument(); 
    
            while (bsonReader.ReadBsonType() != BsonType.EndOfDocument) 
            { 
                var name = bsonReader.ReadName(); 
    
                var field = actualType.GetField(name); 
                if (field != null) 
                { 
                    var value = BsonSerializer.Deserialize(bsonReader, field.FieldType); 
                    field.SetValue(obj, value); 
                } 
    
                var prop = actualType.GetProperty(name); 
                if (prop != null) 
                { 
                    var value = BsonSerializer.Deserialize(bsonReader, prop.PropertyType); 
                    prop.SetValue(obj, value, null); 
                } 
            } 
    
            bsonReader.ReadEndDocument(); 
    
            return obj; 
        } 
    
        public object Deserialize(BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options) 
        { 
            return Deserialize(bsonReader, nominalType, nominalType, options); 
        } 
    
        public bool GetDocumentId(object document, out object id, out Type idNominalType, out IIdGenerator idGenerator) 
        { 
            throw new NotImplementedException(); 
        } 
    
        public void SetDocumentId(object document, object id) 
        { 
            throw new NotImplementedException(); 
        } 
    } 
