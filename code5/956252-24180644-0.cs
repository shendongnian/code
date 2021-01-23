      [Test]
      public void SomeTest()
      {
         var mock = new Mock<DefaultImplementation>().As<IInterface>();
         mock.Setup(i => i.Method(It.IsAny<int>()))
             .Returns<int>(p => p == 0 
                                     ? 5 
                                     : ((DefaultImplementation)mock.Object).Method(p));
         TheMethodITest(mock.Object);
      }
