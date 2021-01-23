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
			// or simpler remove the WriteInternal function and use the next line:
			// txtLog.Invoke(new Action(() => txtLog.Text += message + Environment.NewLine));
		}
	}
