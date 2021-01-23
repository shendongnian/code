    [DataContract]
    public class MyObject
    {
    	[DataMember] // data contract on backing field
        private string _Name;
    
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        [DataMember] // data contract on backing field
        private int? _TestInt;  
    
        public int? TestInt
        {
            get { return _TestInt; }
            set { _TestInt = value; }
        }
    
        public MyObject()
        {
            _Name = "";
            _TestInt = 0;
        }
    }
