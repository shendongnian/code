    class A
    {
        private double[] _temperatures;
        public double[] Temperature
        {
            get { return _temperatures; }
            set { _temperatures = value; }
        }
    }
    class B : A
    {
        public B()
        {
            B b = new B();
            Console.WriteLine(b.Temperature);
        }
    }
