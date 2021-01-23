    var actionList= new List<Action>();
    
    actionList.Add(() => SomeAwesomeMethod());
    actionList.Add(() => foo.MyOtherAwesomeMethod());
    actionList.Add(() => bar.ThisWillBeAwesome(foo));
    
    foreach(var action in actionList)
    {
        action();
    }
