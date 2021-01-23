    public class KVPair
    {
        public string Key { get; set; }
        public string[] Value { get; set; }
    }
    
    KVPair pair = JsonConvert.DeserializeObject<KVPair>(UTF8Encoding.UTF8.GetString(data));
