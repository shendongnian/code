    class foo
    { 
       public delegate void myEvntHandler();
       public event myEvntHandler onTesting;
    
        public void RaiseEvent()
        {
            if(onTesting !=null)
                onTesting ();
        }
    }
