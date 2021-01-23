    class A   //<-- this class is static?????
    {
      public string b;
      public int c;
      public bool d;
      public A e;
      
      public A() { }  // add default constructor
      public A(A a){
         b = a.b;
         c = a.c;
         d = a.d;
         if ( a.e != null ) {
            e = new A(a.e);
         }
      }
    }
