	public async Task TestFunction(TestObject obj)
	{
		if(obj != null) {//if null don't do anything 
			obj.name = "Test Name";
			repository.Insert(obj);
		}
    }
