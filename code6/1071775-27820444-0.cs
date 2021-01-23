    class Foo
    {
        public int Bar1 { get; set; }
        public int Bar2 { get; set; }
        public Foo()
        {
            Bar1 = 2;
            Bar2 = 3;
        }
        public int GetBar(int barNum) //return type should be Button for you
        {
            PropertyInfo i = this.GetType().GetProperty("Bar"+barNum);
            if (i == null)
                throw new Exception("Bar" + barNum + " does not exist");
            return (int)i.GetValue(this); //you should cast to Button instead of int
        }
    }
