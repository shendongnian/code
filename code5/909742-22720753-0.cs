    public partial class VisualLogger : Form, ILogger
	{
		public VisualLogger()
		{
			InitializeComponent();
			txtLog.Clear();
		}
		private void WriteInternal(string message)
		{
			txtLog.Text += message + Environment.NewLine;
		}
		public void Write(string message)
		{
			txtLog.Invoke(new Action<string>(WriteInternal), message);
		}
	}
