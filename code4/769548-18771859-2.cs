    public class SerializableDictionary : Dictionary<string, object>
    {
        public static explicit operator SerializableDictionary(String serialized)
        {
            return JsonConvert.DeserializeObject<SerializableDictionary>(serialized);
        }
        public static explicit operator String(SerializableDictionary dict)
        {
            return JsonConvert.SerializeObject(dict);
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
