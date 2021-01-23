    public class EvaluationResultMongoSerializer : IBsonSerializer, IBsonIdProvider 
    {
        public object Deserialize(BsonReader bsonReader, Type nominalType, Type actualType, IBsonSerializationOptions options)
        {
            throw new NotImplementedException();
        }
        public object Deserialize(BsonReader bsonReader, Type nominalType, IBsonSerializationOptions options)
        {
            EvaluationResult er = new EvaluationResult();
            bsonReader.ReadStartDocument();
            er.Id = bsonReader.ReadObjectId();
            er.DurationInSeconds = bsonReader.ReadDouble();
            er.startTime = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(bsonReader.ReadDateTime());
            er.endTime = BsonUtils.ToDateTimeFromMillisecondsSinceEpoch(bsonReader.ReadDateTime());
            er.Result = EvaluationStatus.Parse(bsonReader.ReadString());
            er.JSON = bsonReader.ReadString();
            bsonReader.ReadEndDocument();
            return er;
        }
        public IBsonSerializationOptions GetDefaultSerializationOptions()
        {
            return null;
        }
        public void Serialize(BsonWriter bsonWriter, Type nominalType, object value, IBsonSerializationOptions options)
        {
            EvaluationResult er = (EvaluationResult)value;
            
            bsonWriter.WriteStartDocument();
            bsonWriter.WriteObjectId("_id", er.Id);
            bsonWriter.WriteDouble("Duration", er.DurationInSeconds);
            bsonWriter.WriteDateTime("Start", BsonUtils.ToMillisecondsSinceEpoch(er.startTime));
            bsonWriter.WriteDateTime("End", BsonUtils.ToMillisecondsSinceEpoch(er.endTime));
            bsonWriter.WriteString("Result", er.Result.ValueAsString);
            bsonWriter.WriteString("JSON", er.JSON);
            bsonWriter.WriteEndDocument();
        }
        public bool GetDocumentId(object document, out object id, out Type idNominalType, out IIdGenerator idGenerator)
        {
            idNominalType = typeof(ObjectId);
            idGenerator = ObjectIdGenerator.Instance;
            var mongoDocument = document as EvaluationResult;
            if (mongoDocument == null)
            {
                id = null;
                return false;
            }
            id = mongoDocument.Id;
            return true;
        }
        public void SetDocumentId(object document, object id)
        {
            var mongoDocument = document as EvaluationResult;
            if (mongoDocument != null)
            {
                mongoDocument.Id = (ObjectId)id;
            }
        }
    }
