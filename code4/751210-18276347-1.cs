    JsonSerializer ser = new JsonSerializer();
    var jObj = ser.Deserialize(new JReader(new StringReader(json))) as JObject;
    var newJson = jObj.ToString(Newtonsoft.Json.Formatting.None);
.
    public class JReader : Newtonsoft.Json.JsonTextReader
    {
        public JReader(TextReader r) : base(r)
        {
        }
        public override bool Read()
        {
            bool b = base.Read();
            if (base.CurrentState == State.Property && ((string)base.Value).Contains(' '))
            {
                base.SetToken(JsonToken.PropertyName,((string)base.Value).Replace(" ", "_"));
            }
            return b;
        }
    }
