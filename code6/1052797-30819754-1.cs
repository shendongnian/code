    public class MyCustomException : Exception
    {
        public string MyCustomData { get; set; }
        protected MyCustomException (SerializationInfo info, StreamingContext context) : base(info, context)
        {
            MyCustomData = info.GetString("MyCustomData");
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("MyCustomData", MyCustomData);
        }
    }
