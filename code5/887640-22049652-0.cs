    public class CommandListBoxItem : ListBoxItem 
    {
        public static readonly DependencyProperty ButtonCommandProperty = 
            DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(CommandListBoxItem), null);
        public bool ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }
        public CommandListBoxItem()
        {
            DefaultStyleKey = typeof(CommandListBoxItem);
        }
    }
