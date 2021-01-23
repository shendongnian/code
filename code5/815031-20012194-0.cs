        public object mutex = new object();
        public void IEAction(string action)
        {
             lock(mutex)
             {
                 //serialized logic goes here
             }
        }
