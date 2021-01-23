    public static class MyObjectDTOConverter
    {
    	public static MyObjectDTO ToSerializable(MyObject myObj)
    	{
    		return new MyObjectDTO {
    			SomeValue = myObj.SomeValue,
    			SomeValueUpdated = myObj.SomeValueUpdated
    		};
    	}
    	
    	public static MyObject FromSerializable(MyObjectDTO myObjSerialized)
    	{
    		return new MyObject(
    		    myObjSerialized.SomeValue, 
    		    myObjSerialized.SomeValueUpdated
    		);
    	}
    }
