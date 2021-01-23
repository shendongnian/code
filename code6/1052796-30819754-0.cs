    public class MyCustomException : Exception
    {
        public object MyCustomObject { get; set; }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("MyCustomObject", MyCustomObject);
        }
    }
