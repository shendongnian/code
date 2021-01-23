	public partial class ContentButton : ContentView
	{
		public ContentButton()
		{
			InitializeComponent();
		}
		public event EventHandler Tapped;
		public static readonly BindableProperty CommandProperty = BindableProperty.Create<ContentButton, ICommand>(c => c.Command, null);
		public ICommand Command
		{
			get { return (ICommand)GetValue(CommandProperty); }
			set { SetValue(CommandProperty, value); }
		}
		private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
		{
			if(Tapped != null)
				Tapped(this,new EventArgs());
		}
	}
