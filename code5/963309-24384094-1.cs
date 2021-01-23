    class A
    {
        public Fun1(IB ib) { ib.Fun2(); }
    }
    
    interface IB
    {
    	Fun2();
    }
    
    class B : IB
    {
        public Fun2() {}
    }
    
    // Test Class for Class A
    Class A_Test
    {
        Fun1_Test()
        {
    		var bMock = new Mock<IB>();
    		bMock.Setup(b => b.Fun2());
    
    	    A obj1 = new A();
    	    A.Fun1(bMock.Object);
        }
    }
