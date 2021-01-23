    public class Class1()
    {
        private IOtherClass _otherClass; // depend on this abstraction
    
        public Class1(IOtherClass otherClass) // constructor injection
        {
            _otherClass = otherClass;
        }
    
        public string getSomeString(string input)
        {
            //dosomething
            return _otherClass.getData(); // you don't know implementation
        }
    }
