     public class KeyUpBinding : InputBinding
    {
        public Key Key
        {
            get { return (Key)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }
        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(Key), typeof(KeyUpBinding), new PropertyMetadata(Key.A, KeyChanged));
        private static void KeyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var keybinding = (d as KeyUpBinding);
            Keyboard.AddKeyUpHandler(App.Current.MainWindow, (s, ku) =>
            {
                if(keybinding.Command!=null && ku.Key == keybinding.Key && ku.IsUp)
                {
                    keybinding.Command.Execute(null);
                }
            });
        }
       
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(KeyUpBinding), new PropertyMetadata(null));
       
    }
