    public void DoSomething(UserControl control,Action callback)
    {
        control.SomeProperty = 1;
        callback();
    }
    DoSomething(usercontrol,usercontrol.MethodWithNoArgs);
