    public void GetDataLINQ_AlwaysInvokesDequeueTestProject()
    {
    	//create a fake implementation of IDataRepository
    	var repo = new FakeFilledDatabaseRepository();	
    	var sut = new MyPageClass();
        //stick in the stub:
        sut.SetTestRepo(repo);
    	//call the method
    	sut.GetDataLINQ();
    	//Verify that repo.DequeueTestProject() was indeed called.
    	var expected=1;
    	Assert.AreEqual(expected,repo.CallCount);
    }
