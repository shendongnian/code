    public class QueryDocumentSerializer : BsonBaseSerializer
    	{
    		public override object Deserialize(MongoDB.Bson.IO.BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options)
    		{
    			if (bsonReader.GetCurrentBsonType() == BsonType.Null)
    			{
    				bsonReader.ReadNull();
    				return null;
    			}
    			else
    			{
    				var value = bsonReader.ReadString();
    				var doc = BsonDocument.Parse(value);
    				var query = new QueryDocument(doc);
    				return query;
    			}
    		}
    
    		public override void Serialize(MongoDB.Bson.IO.BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
    		{
    			if (value == null)
    			{
    				bsonWriter.WriteNull();
    			}
    			else
    			{
    				var query = (QueryDocument)value;
    				var json = query.ToJson();
    				bsonWriter.WriteString(json);
    			}
    		}
    	}
