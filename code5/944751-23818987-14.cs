    public void GetDataLINQ_ReturnsNCommandMessagesIfDatabaseNotEmpty()
    {
    //create a fake implementation of IDataRepository
    	var repo = new Mock<IDataRepository>();
    	//set it up to return null; 
    	repo.Setup(r=>r.DequeueTestProject()).Returns(new CommandMessages("fake","fake","fake");
    	var sut = new MyPageClass(repo.Object);
    	//call the method but store the result this time:
    	var actual = sut.GetDataLINQ();
    	//Verify that the result is indeed NULL:
    	Assert.IsNotNull(actual);
    }
