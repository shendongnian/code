    public class Type1 : Base<MyString>
    {
        public override DataType Type
        {
            get { return DataType.MyString; }
        }
    
        public override MyString Value
        {
            get;
            set;
        }
    }
