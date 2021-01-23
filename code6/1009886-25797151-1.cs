    public class Pen
    {
    	int _ink = 1000;
    	
    	public Pen(int ink)
    	{
    		_ink = ink;
    	}
    }
    
    void Test()
    {
    	//Create the object and check constructor set the value
    	var pen = new Pen(5);
    	var field = pen.GetType().GetField("_ink", BindingFlags.NonPublic|BindingFlags.Instance);
    	
    	// This should pass.
    	Debug.Assert((int)field.GetValue(pen) == 5);
    	
    	// Create the pen without using constructor. 
    	// No matter what, nothing is initialized meaning _ink is 0 and not 1000.
    	// Hence, uninitialized.
    	var uninitializedPen = (Pen)FormatterServices.GetUninitializedObject(typeof(Pen));
    	field = uninitializedPen.GetType().GetField("_ink", BindingFlags.NonPublic|BindingFlags.Instance);
    	
    	//This will fail.
    	Debug.Assert((int)field.GetValue(uninitializedPen) == 1000);
    }
