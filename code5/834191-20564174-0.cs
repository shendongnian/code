    Mock<IFoo> foo = new Mock<IFoo>(MockBehavior.Strict);
    bool isFirstCall = true;
    foo.Setup(item => item.GetInt())
       .Returns(() =>
       {
           if (isFirstCall)
           {
               isFirstCall = false;
               return 0;
           }
           return 10;
       });
