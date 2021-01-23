    public static class Extensions 
    {
    	public static Object1DTO ToDTO(this Object1 object1)
    	{
    		return new Object1DTO { Property = object1.Property };
    	}
    }
