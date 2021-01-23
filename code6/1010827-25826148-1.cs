        public delegate void Del();
        public Del MyDel;
        public MainWindow(string imAStringSentToAConstructorBySomeone)
        {         
            // Edit :
         
           MyDel += (Del)Delegate.CreateDelegate(typeof(Del), this,imAStringSentToAConstructorBySomeone);
           // Full Answer
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
