    public class Class1()
    {
        private IOtherClass _otherClass;
    
        public Class1(IOtherClass otherClass) 
        {
            _otherClass = otherClass;
        }
    
        public string getSomeString(string input)
        {
            //dosomething
            return _otherClass.getData();
        }
    }
