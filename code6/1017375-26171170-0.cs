    public class LineInfo
    {
        [JsonIgnore]
        public int LineNumber { get; set;}
        [JsonIgnore]
        public int LinePosition { get; set;}        
    }
    public abstract class JsonLineInfo : LineInfo
    {
        [JsonIgnore]
        public Dictionary<string, LineInfo> PropertyLineInfos { get; set; }
    }
    class LineNumberConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Converter is not writable. Method should not be invoked");
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(JsonLineInfo).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Null)
            {
                int lineNumber = 0;
                int linePosition = 0;
                var jsonLineInfo = reader as IJsonLineInfo;
                if (jsonLineInfo != null && jsonLineInfo.HasLineInfo())
                {
                    lineNumber = jsonLineInfo.LineNumber;
                    linePosition = jsonLineInfo.LinePosition;
                }
                var rawJObject = JObject.Load(reader);
                var lineInfoObject = Activator.CreateInstance(objectType) as JsonLineInfo;
                serializer.Populate(this.CloneReader(reader, rawJObject), lineInfoObject);
                return this.PopulateLineInfo(
                    lineInfoObject: lineInfoObject,
                    lineNumber: lineNumber,
                    linePosition: linePosition,
                    rawJObject: rawJObject);
            }
            return null;
        }
        private JsonReader CloneReader(JsonReader reader, JObject jobject)
        {
            var clonedReader = jobject.CreateReader();
            clonedReader.Culture = reader.Culture;
            clonedReader.DateParseHandling = reader.DateParseHandling;
            clonedReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
            clonedReader.FloatParseHandling = reader.FloatParseHandling;
            clonedReader.MaxDepth = reader.MaxDepth;
            return clonedReader;
        }
        private object PopulateLineInfo(JsonLineInfo lineInfoObject, int lineNumber, int linePosition, JObject rawJObject)
        {
            if (lineInfoObject != null)
            {
                lineInfoObject.PropertyLineInfos = new Dictionary<string, LineInfo>(StringComparer.InvariantCultureIgnoreCase);
                lineInfoObject.LineNumber = lineNumber;
                lineInfoObject.LinePosition = linePosition;
                foreach (var property in rawJObject.Properties().CoalesceEnumerable())
                {
                    var propertyLineInfo = property as IJsonLineInfo;
                    if (propertyLineInfo != null)
                    {
                        lineInfoObject.PropertyLineInfos.Add(
                            property.Name,
                            new LineInfo
                            {
                                LineNumber = propertyLineInfo.LineNumber,
                                LinePosition = propertyLineInfo.LinePosition
                            });
                    }
                }
            }
            return lineInfoObject;
        }
    }
