    class A
    {
       Fun1(B b)
       {
          b.Fun2();
       }
    }
    
    //test method
    Fun1_Test()
    {
    	var bMock = new Mock<B>();
    	bMock.Setup(b => b.Fun2());
    
        A obj1 = new A();
        A.Fun1(bMock.Object);
    }
