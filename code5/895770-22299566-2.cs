    public class ListItemVm : DependencyObject
    {
		public string ItemText
		{
			get { return (string)GetValue(ItemTextProperty); }
			set { SetValue(ItemTextProperty, value); }
		}
		public static readonly DependencyProperty ItemTextProperty =
			DependencyProperty.Register("ItemText", typeof(string), typeof(ListItemVm), new UIPropertyMetadata(""));
    }
    public class ButtonVm : DependencyObject
    {
		public string ButtonText
		{
			get { return (string)GetValue(ButtonTextProperty); }
			set { SetValue(ButtonTextProperty, value); }
		}
		public static readonly DependencyProperty ButtonTextProperty =
			DependencyProperty.Register("ButtonText", typeof(string), typeof(ButtonVm), new UIPropertyMetadata(""));
		public Command ButtonCommand
		{
			get { return (string)GetValue(ButtonCommandProperty); }
			set { SetValue(ButtonCommandProperty, value); }
		}
		public static readonly DependencyProperty ButtonCommandProperty =
			DependencyProperty.Register("ButtonCommand", typeof(Command), typeof(ButtonVm), new UIPropertyMetadata(""));
    }
    public class Command : ICommand { /* simple implementation of ICommand */ }
