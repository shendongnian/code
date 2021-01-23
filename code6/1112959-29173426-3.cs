    public class SessionPermissionConverter : JsonConverter
    {
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var obj = (JObject)JObject.ReadFrom(reader);
            
            
            JProperty property = obj.Properties().FirstOrDefault();
            
            return new SessionPermission
            {
                Permission = property.Name,
                IsAllowed = property.Value.Value<bool>()
            };
        }
        
        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
           SessionPermission permission = (SessionPermission)value;
           
           JObject obj = new JObject();
           
           obj[permission.Permission] = permission.IsAllowed;
           
           obj.WriteTo(writer);
        }
            
        public override bool CanConvert(Type t)
        {
            return typeof(SessionPermission).IsAssignableFrom(t);
        }
        
        public override bool CanRead
        {
            get { return true; }
        }
    }
