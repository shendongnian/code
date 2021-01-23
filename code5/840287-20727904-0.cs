    public class DeserializedObject{
        public string processLevel{get;set;}
        public object segments{get;set}
    }
    IEnumerable<DeserializedObject> object=jsonSerializer.Deserialize<IEnumerable<DeserializedObject>>(json);
