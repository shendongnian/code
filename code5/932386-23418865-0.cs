    [Test]
    public void Throws_exception_when_already_connected()
    {
           var foo = new Foo();
           foo.Connect();
      
    
           Exception thrownExc = null;
    
           try
           {
                foo.Connect();
           }
           catch(InvalidOperationException exc)
           {
               thrownExc = exc;
           }
           
           Assert.IsNotNull(thrownExc, "It was expected to get exception on 2nd connect attempt, but nothing were thrown.");
    }
