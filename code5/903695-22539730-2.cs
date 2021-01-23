    class HolderConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Holder));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Holder holder = new Holder();
            holder.ObjType = (int)jo["ObjType"];
            holder.Objects = new List<Base>();
            foreach (JObject obj in jo["Objects"])
            {
                if (holder.ObjType == 1)
                    holder.Objects.Add(obj.ToObject<DerivedType1>(serializer));
                else
                    holder.Objects.Add(obj.ToObject<DerivedType2>(serializer));
            }
            return holder;
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
