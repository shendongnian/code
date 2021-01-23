    ISampleInterface a = new A();
    ISampleInterface b = new B();
    ISampleInterface c = new C();
    a.Method(); // calls A.Method
    b.Method(); // calls explicit ISampleInterface.Method
    ((B)b).Method(); // calls A.Method
    c.Method(); // calls C.Method
    ((A)c).Method(); // calls A.Method
