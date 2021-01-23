	public partial class Form1 : Form
	{
		public static int Counter;
		public static int Cnt => Interlocked.Increment(ref Counter);
		private readonly TextBox _txt = new TextBox();
		public static void WriteTrace(string from) => Trace.WriteLine($"{Cnt}:{from}:{Thread.CurrentThread.Name ?? "ThreadPool"}");
		public Form1()
		{
			InitializeComponent();
			Thread.CurrentThread.Name = "ThreadUI!";
			//this seems to be so nice :)
			_txt.TextChanged += (sender, args) => { TestB(); };
			WriteTrace("Form1"); TestA(); WriteTrace("Form1");
		}
		private void TestA()
		{
			WriteTrace("TestA.Begin");
			Task.Factory.StartNew(() => WriteTrace("TestA.StartNew"))
			.ContinueWith(t =>
			{
				WriteTrace("TestA.ContinuWith");
				_txt.Text = @"TestA has completed!";
			}, TaskScheduler.FromCurrentSynchronizationContext());
			WriteTrace("TestA.End");
		}
		private void TestB()
		{
			WriteTrace("TestB.Begin");
			Task.Factory.StartNew(() => WriteTrace("TestB.StartNew - expected ThreadPool"))
			.ContinueWith(t => WriteTrace("TestB.ContinueWith1 should be ThreadPool"))
			.ContinueWith(t => WriteTrace("TestB.ContinueWith2"));
			WriteTrace("TestB.End");
		}
	}
