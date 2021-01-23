    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class info : ExpandableObjectConverter
    {
        private int _id;
            
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    
    }
