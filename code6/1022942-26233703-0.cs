    public class MyView : UserControl
    {
        public MyView()
        {
            InitializeComponent();
            MouseButtonEventHandler handler = OnComboBoxClicked;
			radComboBox.AddHandler( UIElement.MouseLeftButtonDownEvent, handler,
                handledEventsToo: true );
        }
        private void OnComboBoxClicked( object sender, MouseButtonEventArgs args )
		{
			if (!args.Handled ||
                !args.IsRoutedEventFromToggleButton(
                    togglebuttonAncestorToStopTheSearch: (UIElement) sender))
			{
				ToggleDropDown();
			}
		}
    }
