	public class MySpeechMethods
	{
		[Speech("Open Notepad")]
		public void OpenNotepad()
		{
           System.Diagnostics.Process.Start(@"C:\Windows\System32\Notepad.exe");
		}
    //...
