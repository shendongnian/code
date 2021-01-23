    class a
    {
        int x;
        void somemethod1()
        {
            x=10;  //this will work fine 
        }
    }
    class b
    {
        int y;
        void somemethod2()
        {
           a a1=new a();
           a1.x=10; //this wont work because a1.x is private ... can only be accessible my members of class a
        }
    
    }
