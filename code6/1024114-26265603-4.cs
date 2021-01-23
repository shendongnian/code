    AbsDoc temp=null; 
    
    if(param=="A")
    {
      var a =new A();
      a.SomeMethodA();
      temp = a;
    }
    else 
    {
      var b =new B();
      v.SomeMethod();
      temp = b;
    }
    temp.DoIt();
