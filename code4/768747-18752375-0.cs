    class A {
       
       public A() { a= 1; }
       public A(double dummy); { }
    }
    class B 
       public B() : base() {  // calls the base constructor that does something
       }
       public B(int) : base(1.0) {// class the base construct that does nothing 
       }
    }
      
