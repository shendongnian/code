    public class GalleryImageConverter : JsonConverter
    {   
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(GalleryImage) || objectType == typeof(GalleryAlbum));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                if (!CanConvert(objectType))
                    throw new InvalidDataException("Invalid type of object");
                JObject jo = JObject.Load(reader);
                // following is to avoid use of magic strings
                var isAlbumPropertyName = ((MemberExpression)((Expression<Func<GalleryImage, bool>>)(s => s.is_album)).Body).Member.Name;
                JToken jt;
                if (!jo.TryGetValue(isAlbumPropertyName, StringComparison.InvariantCultureIgnoreCase, out jt))
                {
                    return jo.ToObject<GalleryImage>();
                }
                var propValue = jt.Value<bool>();
                if(propValue) {
                    resultType = typeof(GalleryAlbum);
                }
                else{
                    resultType = typeof(GalleryImage);
                }
                var resultObject = Convert.ChangeType(Activator.CreateInstance(resultType), resultType);
                var objectProperties=resultType.GetProperties();
                foreach (var objectProperty in objectProperties)
                {
                    var propType = objectProperty.PropertyType;
                    var propName = objectProperty.Name;
                    var token = jo.GetValue(propName, StringComparison.InvariantCultureIgnoreCase);
                    if (token != null)
                    {
                        objectProperty.SetValue(resultObject,token.ToObject(propType)?? objectProperty.GetValue(resultObject));
                    }
                }
                return resultObject;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
