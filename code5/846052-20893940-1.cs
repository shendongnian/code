    public class MyObject
    {
        public ChildObject MyChildObject;
        public string MyChildObjectId;
        [JsonProperty("ChildObject")]
        public object ChildObject
        {
            get
            {
                return MyChildObject;
            }
            set
            {
                if (value is JObject)
                {
                    MyChildObject = ((JToken)value).ToObject<ChildObject>();
                    MyChildObjectId = MyChildObject.Id;
                }
                else
                {
                    MyChildObjectId = value.ToString();
                    MyChildObject = null;
                }
            }
        }
    }
