    B b = new B();
    A a = new A(b);
    A a1 = new A(b);  
    A a2 = new A(b); // multiple subscribers to the same publisher
    b.Button_Click();
