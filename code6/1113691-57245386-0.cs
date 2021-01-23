    b.ToggleMe(); //b's value has changed. 
    //b = b.ToggleMe(); // assign back to itself is not necessary. 
    public static class UT
    {
    	public static bool ToggleMe (this ref bool b)
    	{
    		b=!b;     //toggle job is done.
    		return b; //extra return value allows it being used inside expression.
    	}
    }
