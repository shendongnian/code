    AbsDoc temp=null; 
    
    if(param=="A")
    {
      temp=new A();
    }
    else 
    {
      temp=new B();
    }
    
    temp.SomeMethodA();//it gets error when i try to access 
