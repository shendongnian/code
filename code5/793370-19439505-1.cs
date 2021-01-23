    [Export(typeof(IPacketSurrogateProvider))]
    class FirstPacketSurrogateProvider : IPacketSurrogateProvider, ISerializationSurrogate
    {
        public void AddSurrogate(SurrogateSelector toSelector)
        {
            toSelector.AddSurrogate(typeof(FirstPacket), new StreamingContext(StreamingContextStates.All), this);
        }
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", ((FirstPacket)obj).Name);
        }
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            ((FirstPacket)obj).Name = info.GetString("Name");
            return obj;
        }
    }
    [Export(typeof(IPacketSurrogateProvider))]
    class SecondPacketSurrogateProvider : IPacketSurrogateProvider, ISerializationSurrogate
    {
        public void AddSurrogate(SurrogateSelector toSelector)
        {
            toSelector.AddSurrogate(typeof(SecondPacket), new StreamingContext(StreamingContextStates.All), this);
        }
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Measurement", ((SecondPacket)obj).Measurement);
        }
        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            ((SecondPacket)obj).Measurement = info.GetDecimal("Measurement");
            return obj;
        }
    }
