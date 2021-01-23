    static MyTextBox 
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MyTextBox), new FrameworkPropertyMetadata(typeof(MyTextBox)));
        TextBox.TextProperty.OverrideMetadata(typeof(MyTextBox), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTextPropertyChanged)));
    }
    // Add your handlers as above
