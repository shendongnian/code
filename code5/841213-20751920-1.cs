    [DataContract]
    public class geometry<T> where T : struct
    {
        [DataMember]
        public readonly string type = typeof(T).Name;
	
        [DataMember]
        public T coordinates;
    }
    var geom = new geometry<float>();
    Console.WriteLine(geom.type); // Single
