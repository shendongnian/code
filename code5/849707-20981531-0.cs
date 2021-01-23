    public class OwnerClass
    {
        public List<SomeObject> SomeObjects { get; set; }
        public List<OtherObject> OtherObjects { get; set; }
        public object AllObjects 
        {
            get
            {
                List<object> list = SomeObjects;
                list.AddRange(OtherObjects);
                return list;
            }
        }
    } 
