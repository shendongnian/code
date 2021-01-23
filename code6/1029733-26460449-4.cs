    public partial class MyUserControlWithVisualStates : UserControl
    {
        private bool m_isMouseOver;
		public MyUserControlWithVisualStates()
		{
			InitializeComponent();
			RootGrid.MouseEnter += OnRootGridMouseEnter;
			RootGrid.MouseLeave += OnRootGridMouseLeave;
		}
		private void UpdateVisualStates()
		{
			if ( m_isMouseOver )
				VisualStateManager.GoToState( this, "MouseOver", true );
			else
				VisualStateManager.GoToState( this, "Normal", true );
		}
		private void OnRootGridMouseLeave( object sender, MouseEventArgs e )
		{
			m_isMouseOver = false;
			UpdateVisualStates();
		}
		private void OnRootGridMouseEnter( object sender, MouseEventArgs e )
		{
			m_isMouseOver = true;
			UpdateVisualStates();
		}
    }
