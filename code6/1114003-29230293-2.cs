    public IEnumerable<string> Buttons {
        get { return (IEnumerable<string>)GetValue(ButtonsProperty); }
        set { SetValue(ButtonsProperty, value); }
    }
    public static readonly DependencyProperty ButtonsProperty =
        DependencyProperty.Register("Buttons", typeof(IEnumerable<string>),
        typeof(MyUserControl));
