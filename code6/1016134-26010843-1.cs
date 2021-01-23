    [Test]
    public void TestSomeBusinessFunctionality()
    {
    	MyDependency mockedDependency;
    	
    	// setup mock
    	// mock calls on mockedDependency
    	
    	MyClass myClass = new MyClass(mockedDependency);
    	
    	var result = myClass.DoSomethingOrOther();
    	
    	// assertions on result
    	// if necessary assertion on calls on mockedDependency
    }
