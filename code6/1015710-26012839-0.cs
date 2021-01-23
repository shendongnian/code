    [Serializable]
    public class Thing : ISerializable
    {
        public int Id { get; set; }
        public IItem MyItem { get; set; }
        public Thing(SerializationInfo info, StreamingContext context){
        {
            //Do deserialization and handle IItem object
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //Do serialization
        }
    }
