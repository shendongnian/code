    Dicitonary<Action<string>, MyEventArg> delegates = new Dicitonary<Action<string>, MyEventArg>();
    new Thread(
    delegate() 
    { 
      while(true)
      {
        foreach ( var a in delegates) {
          a.Key(a.value);
        }
      }
    }
    ).Start();
