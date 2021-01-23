    public void GetDataLINQ_AlwaysInvokesDequeueTestProject()
    {
    	//create a fake implementation of IDataRepository
    	var repo = new Mock<IDataRepository>();
    	//set it up to just return null; we don't care about the return value for now
    	repo.Setup(r=>r.DequeueTestProject()).Returns(null);
    	//create the SUT, passing in the fake repository
    	var sut = new MyPageClass(repo.Object);
    	//call the method
    	sut.GetDataLINQ();
    	//Verify that repo.DequeueTestProject() was indeed called.
    	repo.Verify(r=>r.DequeueTestProject(),Times.Once);
    }
