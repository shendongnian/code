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
            jo.Add("Items", JArray.FromObject(result.ToArray(), serializer));
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            PagedResult<T> result = new PagedResult<T>();
            result.PageSize = (int)jo["PageSize"];
            result.PageIndex = (int)jo["PageIndex"];
            result.TotalItems = (int)jo["TotalItems"];
            result.TotalPages = (int)jo["TotalPages"];
            result.AddRange(jo["Items"].ToObject<T[]>(serializer));
            return result;
        }
    }
