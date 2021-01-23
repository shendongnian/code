    [MessageContract]
    public class StreamMessage<T1,T2>
    {
        [MessageHeader(MustUnderstand = true)]
        public T1 Val1;
        [MessageHeader(MustUnderstand = true)]
        public T2 Val2;
        [MessageBodyMember(Order = 1)]
        public Stream Stream;
        new public string ToString()
        {
            return "Val1=" + Val1 + ";Stream=" + Stream;
        }
    }
