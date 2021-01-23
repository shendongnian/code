	public partial class MainView : Form, IMainView
	{
		var readonly MainPresenter _presenter;
		public frmInterakcija()
		{
			InitializeComponent();
			_presenter = new MainPresenter(this);
		}
		private void textBox1_KeyPress(object sender, KeyPressEventArgs eventArgs)
		{
			_presenter.ValidateText1();
		}
		
		private void textBox2_KeyPress(object sender, KeyPressEventArgs eventArgs)
		{
			_presenter.ValidateText2();
		}
		
		#region Implementation of IMainView
		
		public string Text1
		{
			get { return textBox1.Text; }
		}
		
		public string Text2
		{
			get { return textBox2.Text; }
		}
		
		public string ErrorMessage
		{
			get { return labelErrorMessage.Text; }
			set { labelErrorMessage.Text = value; }
		}
		
		#endregion
	}
