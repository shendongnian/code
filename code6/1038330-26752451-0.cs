    public class MyControl:Control
    {
    	...
    	public MyControl() 
    	{
    		ExportData = new DelegateCommand(ExportMethod);
    	}
    
        private void ExportMethod()
        {
           string filename = GetFilenameByMagic();
           //Blah blah code to save at filename location.
        }
    	...
    }
