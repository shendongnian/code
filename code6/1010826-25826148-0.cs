        public delegate void Del();
        public Del MyDel;
        public MainWindow()
        {         
            MyDel += () => 
            { 
                
            };
            MyDel += (Del)Delegate.CreateDelegate(typeof(Del), this, "A");
            MyDel += (Del)Delegate.CreateDelegate(typeof(Del), this, "B");
            MyDel.Invoke();
        }
        public void A() 
        {}
        public void B() 
        {}
