    public partial class MyUserControl : UserControl
	{
		private bool m_isMouseOver;
		public MyUserControl()
		{
			InitializeComponent();
			RootGrid.MouseEnter += OnRootGridMouseEnter;
			RootGrid.MouseLeave += OnRootGridMouseLeave;
		}
		private void UpdateBackground()
		{
			if (m_isMouseOver)
				((SolidColorBrush) RootGrid.Background).Color = Colors.Red;
			else
				((SolidColorBrush) RootGrid.Background).Color = Colors.Green;
		}
		private void OnRootGridMouseLeave( object sender, MouseEventArgs e )
		{
			m_isMouseOver = false;
			UpdateBackground();
		}
		private void OnRootGridMouseEnter( object sender, MouseEventArgs e )
		{
			m_isMouseOver = true;
			UpdateBackground();
		}
	}
