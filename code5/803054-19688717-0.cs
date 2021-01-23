    public class SomeClass
    {
        private SomeTypes _SomeType;
        public SomeTypes SomeType { 
            get {return _SomeType;} 
            set {
                if(!Enum.IsDefined(typeof(SomeTypes),value)) 
                    throw new ArgumentException(string.Format("{0} is not a valid SomeTypes value", value),"value");
                _SomeType = value;
            }
        }
    }
