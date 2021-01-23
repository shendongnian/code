    [TestClass]
    public class UnitTest1
    {
    
    	[TestMethod]
    	public void TestMethod1()
    	{
    		var failedTypes = new List<Type>(); //to keep failed types
    
    		foreach (Type type in GetTypesToCheck())
    		{
    			FieldInfo staticField;
    			dynamic definition;
    			if (!CheckStaticField(type, out staticField) 
    					|| !CheckDefinitionPresent(type) 
    					|| !CheckParentDefinition(type, staticField, out definition)
    					|| !CheckRegistration(type, definition) 
    					|| !CheckSubTypes(type, definition))
    				failedTypes.Add(type);
    		}
    
    		Assert.IsTrue(
    			failedTypes.Count == 0, 
    			"Failed types: " + string.Join(", ", failedTypes.Select(t => t.ToString()))
    			);
    	}
    }
