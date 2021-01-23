	public class SomeClass
	{
		System.Windows.Threading.Dispatcher mainThreadDispatcher;		
		// assuming class is instantiated in a main thread, otherwise get a dispatcher to the
		// main thread
		public SomeClass()
		{
			Dispatcher mainThreadDispatcher = Dispatcher.CurrentDispatcher;
		}
		public void MethodCalledFromBackgroundThread()
		{
			mainThreadDispatcher.BeginInvoke((Action)({() => ShowPanel(listBox1);}));
		}
	}
