    [ComVisible(true)]
    public class Foo
    {
    	[ComVisible(false)]
    	public static void Bar() {}
    	
    	public void BarInst()
        {
            Bar();
        }
    }
