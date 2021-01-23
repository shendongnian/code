    public static readonly DependencyProperty PortProperty =
            DependencyProperty.Register
            ("Port", typeof(String), typeof(NameOfYourClass),
            new PropertyMetadata(String.Empty));
    public String Port
        {
            get { return (String)GetValue(PortProperty); }
            set { SetValue(PortProperty, value); }
        }
