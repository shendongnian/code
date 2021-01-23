	public async Task TestFunction(TestObject obj)
	{
		if(obj == null) {
            throw new ArgumentException("obj cannot be null");
		}
		obj.name = "Test Name";
	    repository.Insert(obj);
    }
