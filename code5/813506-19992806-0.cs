    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        var foo = A.Fake<IFoo>(x => x.Strict());
    
        var fakeDataAccess = A.Fake<IDataAccess>();
        
        A.CallTo(() => foo.Execute(A<Action<IDataAccess>>.Ignored))
                        .Invokes((Action<IDataAccess> action)=>action(fakeDataAccess));
    
        var cut = new ClassUnderTest(foo);
    
        // Act
        cut.MethodToTest(new Data { Property = 20 });
    
        // Assert
        A.CallTo(() => fakeDataAccess.Update(A<Data>.That.Matches(d => d.Property == 20)))
            .MustHaveHappened();
    }
