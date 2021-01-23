    class MyClass
    {
    
        public delegate void Del();
        public Del MyDel;
    
        public MyClass(string myString)
        {
            MyDel = (Del)Delegate.CreateDelegate(typeof(Del), this, myString);
        }
    
        public void A() { }
        public void B() { }
    }
