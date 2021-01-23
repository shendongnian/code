    public partial class Form1 : Form
	{
		System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
		int counter = 0;
		public Form1()
		{
			InitializeComponent();
			backgroundWorker1.WorkerReportsProgress = true;
			backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
			backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
			backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
			t1.Interval = 1000;
		}
		void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			progressBar1.Value = 100;
			textBox1.Text = "Done";
		}
		private void button1_Click(object sender, EventArgs e)
		{
			backgroundWorker1.RunWorkerAsync();
			t1.Start();
		}
		void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				System.Diagnostics.Process process = new System.Diagnostics.Process();
				System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
				startInfo.FileName = "cmd.exe";
				string command = "dir /s /b /o:gn";
				startInfo.Arguments = command; // this will take a quit long time to complete
				process.StartInfo = startInfo;
				t1.Tick += new EventHandler(t1_Tick);
				t1.Stop();
			}
			catch (Exception)
			{
			}
		}
		void t1_Tick(object sender, EventArgs e)
		{
			counter = counter + 10;
			backgroundWorker1.ReportProgress(counter);
		}
		void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage <= 90)
				progressBar1.Value = e.ProgressPercentage;
		}
	}
