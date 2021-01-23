    BaseClass.Instance = new BaseClass() { Login = DateTime.Now, Name = "Test" };
    
    ChildA ch = new ChildA();
    
    ChildA ch2 = new ChildA();
    
    childB chb = new childB();
    Response.Write(ch.Login.Millisecond);
    Response.Write("<BR/>");
    Response.Write(chb.Login.Millisecond);
