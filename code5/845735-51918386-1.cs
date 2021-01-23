    public class Example
    {
        //...other properties
        private int _optionalInt;
        public int OptionalInt {
            get => _optionalInt;
            set {
                if (value <= default(int))
                    throw new ArgumentOutOfRangeException("Value cannot be 0 or less");
                else if (value == 10)
                    throw new ArgumentOutOfRangeException("Value cannot be 10");
                else
                    _initValue = value;
            } 
        }
        public Example(int optionalInt)
        {
            OptionalInt = optionalInt; //validation check in constructor
        }
    }
