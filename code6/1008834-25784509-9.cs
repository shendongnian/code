    [Test]
    public void ShouldLoadInput01DataOnButtonClick()
    {
       // Arrange
       IModel data = // create dummy data
    
       Mock<IView_MainForm> clientsViewMock = new  Mock<IView_MainForm>();
       Mock<IRepository> clientsRepositoryMock = new Mock<IRepository>();
       clientsRepositoryMock.Setup(repository => repository.GetData(something)).Returns(data.Input01Data);     
       var presenter = new Presenter(clientsViewMock.Object, clientsRepositoryMock .Object);
     
       // Act
       clientsViewMock.Raise(view => view.LoadInput01 += null, new InputLoadEventArgs());
     
       // Assert
       clientsViewMock.Verify(view => view.SetInput01Data(data.Input01Data), "Input01 data expected be set on button click.");
    }
