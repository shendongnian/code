    public class Foo2{
        private bool calledOnce = false;
        private int _myInt;
        public readonly int myInt{
            get {return _myInt;}
            set {
                if (calledOnce){
                    throw new Exception("Not allowed");
                }else{
                    _myInt = value;
                    calledOnce = true;
                }
            }
        }
        public void start()
        {
            myInt = 1213;
        }
        public void doBad()
        {
            myInt = 1213; // will throw
        }
