    public static readonly DependencyProperty ButtonTopProperty = DependencyProperty.
            Register("ButtonTop", typeof(int), typeof(MainWindowViewModel),
                        new UIPropertyMetadata(ButtonTopPropertyChanged));
        private static void ButtonTopPropertyChanged(DependencyObject sender,
                                             DependencyPropertyChangedEventArgs args)
        {
            // Write synchronization logic here
        }
