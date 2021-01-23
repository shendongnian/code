    internal class TestClass : SomeBaseClass
    {
    	internal virtual void testMethod()
    	{
    		View v = new ViewAnonymousInnerClassHelper();
    	}
    
    	private class ViewAnonymousInnerClassHelper : View
    	{
    		protected internal override void onDraw(Canvas canvas)
    		{
    			System.Console.WriteLine("large view on draw called");
    			base.onDraw(canvas);
    		}
    	}
    }
