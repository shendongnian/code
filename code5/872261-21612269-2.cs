     private void AShouldDelegateWorkToB()
     {
         Mock<InterfaceB> bMock = new Mock<InterfaceB>();     
         A a = new A(bMock.Object);
         a.DoSomething();
         bMock.Verify(b => b.DoSomething(), Times.Once);
     }
