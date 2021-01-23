    class B : ICloneable
    {
       public B(A a_) { a = a_; }
       public A a;
       public B(B b){
           a = new A(b.A);
       }
       public object Clone()
       {
         B newB = new B(this);
         return newB;
       }
    }
    class A
    {
      public int data = 9;
      
      public A(A a){
       data = a.data;
      }
    }
