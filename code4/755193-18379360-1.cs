            static void Main(string[] args)
        {
            using (var ms = new MemoryStream())
            {
                var orig = new SerRoot();
                var ser = new BinaryFormatter();
                System.Console.WriteLine("> serializing");
                ser.Serialize(ms, orig);
                System.Console.WriteLine("< serializing");
                ms.Position = 0;
                System.Console.WriteLine("> deserializing");
                ser.Deserialize(ms);
                System.Console.WriteLine("< deserializing");
            }
        }
    [Serializable]
    class SerRoot : ISerializable
    {
        public SerMember m;
        public SerRoot()
        {
            System.Console.WriteLine("SerRoot.ctor");
            m = new SerMember();
        }
        protected SerRoot(SerializationInfo info, StreamingContext context)
        {
            System.Console.WriteLine("SerRoot.ctor(info, context)");
            m = info.GetValue("m", typeof(SerMember)) as SerMember;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            System.Console.WriteLine("GetObjectData");
            info.AddValue("m", m);
        }
        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context) { System.Console.WriteLine("SerRoot.OnDeserializingMethod"); }
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context) { System.Console.WriteLine("SerRoot.OnDeserializedMethod"); }
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context) { System.Console.WriteLine("SerRoot.OnSerializingMethod"); }
        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context) { System.Console.WriteLine("SerRoot.OnSerializedMethod"); }
    }
    [Serializable]
    class SerMember : ISerializable
    {
        string text;
        public SerMember() 
        { 
            System.Console.WriteLine("SerMember.ctor");
            text = "test";
        }
        protected SerMember(SerializationInfo info, StreamingContext context) 
        {
            System.Console.WriteLine("SerMember.ctor(info, context)");
            text = info.GetString("text");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context) 
        { 
            System.Console.WriteLine("SerMember.GetObjectData");
            info.AddValue("text", text);
        }
        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context) { System.Console.WriteLine("SerMember.OnDeserializingMethod"); }
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context) { System.Console.WriteLine("SerMember.OnDeserializedMethod"); }
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context) { System.Console.WriteLine("SerMember.OnSerializingMethod"); }
        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context) { System.Console.WriteLine("SerMember.OnSerializedMethod"); }
    }
