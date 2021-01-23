    public partial class TestingForm : Form
	{
		
		public TestingForm()
		{
			InitializeComponent();
		}
		private void OnLoad(object sender, EventArgs e)
		{
			cjL_DropPanelCtrl1.PanelParent = splitContainer1.Panel2;
		}
		private void OnSplitter2Moved(object sender, SplitterEventArgs e)
		{
			cjL_DropPanelCtrl1.SetLocation();
		}
	}
