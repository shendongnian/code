    public class MyObject
    {
        private ChildObject _myChildObject;
        public string MyChildObjectId;
        [JsonProperty("ChildObject")]
        public object ChildObject
        {
            get
            {
                return _myChildObject;
            }
            set
            {
                if (value is JObject)
                {
                    _myChildObject = ((JToken)value).ToObject<ChildObject>();
                    MyChildObjectId = _myChildObject.Id;
                }
                else
                {
                    MyChildObjectId = value.ToString();
                    _myChildObject = null;
                }
            }
        }
    }
