    public class GalleryItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(GalleryItem).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, 
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            // Using a nullable bool here in case "is_album" is not present on an item
            bool? isAlbum = (bool?)jo["is_album"];
            GalleryItem item;
            if (isAlbum.GetValueOrDefault())
            {
                item = new GalleryAlbum();
            }
            else
            {
                item = new GalleryImage();
            }
            serializer.Populate(jo.CreateReader(), item);
            return item;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, 
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
