    [DataContract]
    public class TestObject
    {
        private int _id;
        private string _name;
        private decimal _number;
        [DataMember]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        [DataMember]
        public decimal Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }
    }
