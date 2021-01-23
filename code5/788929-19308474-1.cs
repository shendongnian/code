    public class GalleryItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(GalleryItem).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, 
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            if (item["is_album"].Value<bool>())
            {
                return item.ToObject<GalleryAlbum>();
            }
            else
            {
                return item.ToObject<GalleryImage>();
            }
        }
        public override void WriteJson(JsonWriter writer, 
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
