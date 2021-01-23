    [Serializable]
    public class TestClass : ISerializable
    {
        private string _itemTwo;
        private string _itemOne;
        public String ItemTwo
        {
            get { return _itemTwo; }
            set { _itemTwo = value; }
        }
        public String ItemOne
        {
            get { return _itemOne; }
            set { _itemOne = value; }
        }
        protected TestClass(SerializationInfo info, StreamingContext context)
        {
            _itemTwo = info.GetString("<ItemTwo>k__BackingField");
            _itemOne = info.GetString("<ItemOne>k__BackingField");
        }
        [SecurityPermissionAttribute(SecurityAction.Demand,
        SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _itemTwo = info.GetString("<ItemTwo>k__BackingField");
            _itemOne = info.GetString("<ItemOne>k__BackingField");
        }
    }
