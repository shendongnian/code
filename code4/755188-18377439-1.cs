    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    [Serializable]
    class MyClass : ISerializable
    {
        public MyClass() { Trace(); }
        protected MyClass(SerializationInfo info, StreamingContext context) { Trace(); }
        public void GetObjectData(SerializationInfo info, StreamingContext context) { Trace(); }
        void Trace([CallerMemberName] string caller = null)
        {
            System.Console.WriteLine("{0}: {1}", caller, GetType().Name);
        }
        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context) { Trace(); }
    
        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context) { Trace(); }
    
        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context) { Trace(); }
    
        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context) { Trace(); }
    
        static void Main()
        {
            using (var ms = new MemoryStream())
            {
                var orig = new MyClass();
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
    }
