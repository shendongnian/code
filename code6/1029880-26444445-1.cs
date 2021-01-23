        public ObjectToSerialize(SerializationInfo info, StreamingContext context)
        {
            chromosom = (Chromosom)info.GetValue("Chromosom",chromosom.GetType());
            name = (string)info.GetValue("Name",name.GetType());
        }
