    class ChipConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Chip));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Chip chip = new Chip();
            chip.Gates = (int)jo["gates"];
            JArray ja = (JArray)jo["truthtable"];
            if (chip.Gates == 1)
            {
                chip.TruthTable = new List<List<bool>>();
                chip.TruthTable.Add(ja.ToObject<List<bool>>());
            }
            else
            {
                chip.TruthTable = ja.ToObject<List<List<bool>>>();
            }
            return chip;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
