    AbsDoc temp=null; 
    
    if(param=="A")
    {
      temp=new A();
      ((A)temp).SomeMethodA();
    }
    else 
    {
      temp=new B();
      ((B)temp).SomeMethod();
    }
   
