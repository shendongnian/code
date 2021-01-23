        public void Method1(Action action)
        {
            Contact.Requires<ArgumentNullException>(action != null);
        }
    
        public object Method2()
        {
             Contract.Ensures(Contract.Result<object>() != null);
             // code here
         }
    
         public void Method2(Action action == null)
         {
             if (action != null)
                action();
         }
