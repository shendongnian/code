    public class RootObject
    {
        public Dictionary<string, dynamic> Objects { get; set; }
    }
    RootObject deserializedObject = JsonConvert.DeserializeObject<RootObject>(data);
