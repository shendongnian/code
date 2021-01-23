	public partial class frmB : Form
	{
		private Timer buttonTimer = new Timer();
		public frmB()
		{
			InitializeComponent();
			buttonTimer.Tick += new EventHandler(buttonTimer_Tick);
			buttonTimer.Interval = 500;
		}
		private void frmB_Shown(object sender, EventArgs e)
		{
			buttonTimer.Start();
		}
		void buttonTimer_Tick(object sender, EventArgs e)
		{
			btnB.Enabled = true;
			buttonTimer.Stop();
		}
	}
