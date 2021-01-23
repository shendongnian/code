    private static void OnValueChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Window))
            {
                return;
            }
            var window = d as Window;
            if ((bool)e.NewValue)
            {
                InputBinding escapeBinding = new InputBinding(AppCommands.WindowCloseCommand, new KeyGesture(Key.Escape));
                escapeBinding.CommandParameter = window;
                window.InputBindings.Add(escapeBinding);
                window.Closing += Window_Closing;
            }
            else
            {
                window.Closing -= Window_Closing;
            }
        }
    static void Window_Closing(object sender, CancelEventArgs e)
        {
    #if DEBUG
    #else
            e.Cancel = MessageBox.Show(window, "Are you sure?", "Exit",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes;
    #endif
        }
