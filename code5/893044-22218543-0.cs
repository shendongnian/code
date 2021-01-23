    public class ABC
    { 
        private int a; //also you can add 'readonly' if you will not change this value in       its lifetime
        private int b;
        private int c;
        public int A()
        {
            get { return a; }
        }
        public int B()
        {
            get { return b; }
        }
        public int C()
        {
            get { return c; }
        }
        public void Test()
        {     
            a=10;
            b=11;
            c=12;
            //many many variables
        }
    }
