    //Given
    var desiredItem = ...
    Mock<SomeClass> myMock = new Mock<SomeClass>();
    myMock.Setup(x=>x.ChangeItem).Returns(desiredItem);
    var testClass = myMock.Object;
    //When 
    testClass.ChangeItem();
    //Then
    testClass.NewItem.ShouldEqual(....);
   
