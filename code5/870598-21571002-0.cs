    public class Test
    {
        // define some private varibales:
        private int _a;
        private int _b;
        private bool accessA = true;
        private bool accessB = true;
        public int a
        {
            get
            {
                if (accessA)
                {
                    return _a;
                }
                else
                {
                    throw new Exception("At this moment this property was excluded.");
                }
            }
            set
            {
                if (accessA)
                {
                    _a = value;
                }
                else
                {
                    throw new Exception("At this moment this property was excluded.");
                }
            }
        }
        public int b
        {
            get
            {
                if (accessB)
                {
                    return _b;
                }
                else
                {
                    throw new Exception("At this moment this property was excluded.");
                }
            }
            set
            {
                if (accessB)
                {
                    _b = value;
                }
                else
                {
                    throw new Exception("At this moment this property was excluded.");
                }
            }
        }
        public int c { get; set; }
        public int d { get; set; }
        public void ExcludeA()
        {
            accessA = false;
        }
        public void ExcludeB()
        {
            accessB = false;
        }
    }
        public void call1(Test obj)
        {
            //do some work here ....
            obj.ExcludeA();
        }
        public void call2(Test obj)
        {
            // do some work here ...
            obj.ExcludeA();
            obj.ExcludeB();
        }
