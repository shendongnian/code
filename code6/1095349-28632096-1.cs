    public class ClickToEditControl : Control
	{
		public ClickToEditControl()
		{
			DefaultStyleKey = typeof (ClickToEditControl);
			MouseLeftButtonDown += OnMouseLeftButtonDown;
		}
		private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount==2)
			{
				GotoEditMode();
				e.Handled = true;
			}
		}
		protected override void OnLostFocus(RoutedEventArgs e)
		{
			base.OnLostFocus(e);
			if (!this.IsFocused())
				GotoDisplayMode();
		}
		private void GotoDisplayMode()
		{
			IsInEditMode = false;
		}
		private void GotoEditMode()
		{
			IsInEditMode = true;
		}
		
		public DataTemplate EditTemplate
		{
			get { return (DataTemplate) GetValue( EditTemplateProperty ); }
			set { SetValue( EditTemplateProperty, value ); }
		}
		public static readonly DependencyProperty EditTemplateProperty =
			DependencyProperty.Register( "EditTemplate", typeof( DataTemplate ), typeof( ClickToEditControl ), null );
		
		public DataTemplate DisplayTemplate
		{
			get { return (DataTemplate) GetValue( DisplayTemplateProperty ); }
			set { SetValue( DisplayTemplateProperty, value ); }
		}
		public static readonly DependencyProperty DisplayTemplateProperty =
			DependencyProperty.Register( "DisplayTemplate", typeof( DataTemplate ), typeof( ClickToEditControl ), null );
		
		public bool IsInEditMode
		{
			get { return (bool) GetValue( IsInEditModeProperty ); }
			set { SetValue( IsInEditModeProperty, value ); }
		}
		public static readonly DependencyProperty IsInEditModeProperty =
			DependencyProperty.Register( "IsInEditMode", typeof( bool ), typeof( ClickToEditControl ), null );
	}
