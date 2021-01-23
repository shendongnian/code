    public class MyObject
    {
        [JsonIgnore]
        public string ChildObjectId
        {
            get { return ChildObject.Id; }
            // I would advise against having a setter here
            // you should only allow changes through the object only
            set { ChildObject.Id = value; }
        }
    
        [JsonConverter(typeof(MyObjectChildObjectConverter))]
        public ChildObject ChildObject { get; set; }
    }
