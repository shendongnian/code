    class MyClass
    {
        public MyClass()
        {
            this.Url = "http://www.google.com";
        }
        public MyClass(int x)
            : this()
        {
        }
        public String Url { get; set; }
    }
