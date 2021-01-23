    public class number
    {
        public int reason { get; set; }
        public string about { get; set; }
    }
    public class Inf
    {
        public int campaignId { get; set; }
        public string programCode { get; set; }
    }
    public class JSONResponse
    {
        public number number { get; set; }
        public Inf Inf { get; set; }
        public static List<JSONResponse> DeserializeList(string jsonstr)
        {
            return JsonConvert.DeserializeObject<List<JSONResponse>>(jsonstr, new JSONResponseConverter());
        }
    }
    class JSONResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(JSONResponse).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JSONResponse response = new JSONResponse();
            var array = JArray.Load(reader);
            if (array.Count != 2)
            {
                // Or maybe throw an exception?
                Debug.WriteLine("Unexpected array length for " + array.ToString());
            }
            foreach (var entry in array)
            {
                if (entry["campaignId"] != null)
                {
                    response.Inf = entry.ToObject<Inf>();
                }
                else if (entry["reason"] != null)
                {
                    response.number = entry.ToObject<number>();
                }
                else
                {
                    // Or maybe throw an exception?
                    Debug.WriteLine("Unknown entry " + entry.ToString());
                }
            }
            return response;
        }
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
