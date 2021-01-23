    class CustomDataSetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DataSet));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DataSet x = (DataSet)value;
            JObject jObject = new JObject();
            DataTable a = x.Tables["A"];
            foreach (DataColumn col in a.Columns)
            {
                jObject.Add(col.Caption.ToLower(), a.Rows[0][col].ToString());
            }
            JArray jArray = new JArray();
            DataTable b = x.Tables["B"];
            foreach (DataRow row in b.Rows)
            {
                JObject jo = new JObject();
                foreach (DataColumn col in b.Columns)
                {
                    jo.Add(col.Caption.ToLower(), row[col].ToString());
                }
                jArray.Add(jo);
            }
            jObject.Add("details", jArray);
            jObject.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
