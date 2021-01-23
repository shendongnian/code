	public class Demo
	{
		public event EventHandler<String> StringEvent = null;
		public event EventHandler<Int32> IntEvent = null;
		
		public void NotifyOnWork()
		{
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine(i);
				if (this.StringEvent != null) {	this.StringEvent(this, i.ToString()); }
				if (this.IntEvent != null) { this.IntEvent(this, i); }
			}
		}
	}
