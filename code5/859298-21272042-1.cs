    class PagedResultConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(PagedResult<T>));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            PagedResult<T> result = (PagedResult<T>)value;
            JObject jo = new JObject();
            jo.Add("PageSize", result.PageSize);
            jo.Add("PageIndex", result.PageIndex);
            jo.Add("TotalItems", result.TotalItems);
            jo.Add("TotalPages", result.TotalPages);
            jo.Add("Items", JArray.FromObject(result.ToArray()));
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
