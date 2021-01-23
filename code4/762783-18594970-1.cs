    using (var myClientProxy = new MyClientProxy())
    {
      TryServiceCall(myClientProxy.DoSomething);
    }
    using (var myClientProxy = new MyClientProxy())
    {
      int result;
      TryServiceCall( () => result = myClientProxy.GetFavoriteNumber() );
    }
