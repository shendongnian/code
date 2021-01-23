    public static readonly DependencyProperty UserInputTypeProperty =
                DependencyProperty.Register("UserInputType", typeof (InputScope), typeof (ManualTypeView), new PropertyMetadata(default(InputScope)));
    
    public InputScope UserInputType
    {
        get { return (InputScope) GetValue(UserInputTypeProperty); }
        set { SetValue(UserInputTypeProperty, value); }
    }
