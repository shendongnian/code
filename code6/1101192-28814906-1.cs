    public void MyControllerFunction()
    {
        var x = Context["variable"];
        MyControllerLogic(x);
    }
  
    internal void MyControllerLogic(object x)
    {
        do-something-with-x;
    }
