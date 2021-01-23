    [TestCase("aaa")] 
    [TestCase("bbb")] 
    public void MainTest(string str)
    {
      Assert.DoesNotThrow(()=> Test1(new Foo(str)));
      Assert.DoesNotThrow(()=> Test2(new Foo(str)));
    }
    public void Test1(Foo foo)
    {
        // test 1
    }
    
    public void Test2(Foo foo)
    {
        // test 2
    }
    
  
