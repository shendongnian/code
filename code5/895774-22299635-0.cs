    public class ButtonListView : ListView
    {
        static ButtonListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonListView), new FrameworkPropertyMetadata(typeof(ButtonListView)));
        }
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof (ICommand), typeof (ButtonListView), new PropertyMetadata(default(ICommand)));
        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.Register(
            "ButtonContent", typeof (object), typeof (ButtonListView), new PropertyMetadata(default(object)));
        public object ButtonContent
        {
            get { return (object) GetValue(ButtonContentProperty); }
            set { SetValue(ButtonContentProperty, value); }
        }
    }
