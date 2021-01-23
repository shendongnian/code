    [DataContract]
    public class geometry<T> where T : struct
    {
        [DataMember]
        public T coordinates;
    }
