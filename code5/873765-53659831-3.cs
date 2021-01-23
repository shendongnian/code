    public void SomeMethod()
    {
      var myTask = new Task(() => ...);
      myTask.IgnoreExceptions().Start();
    }
