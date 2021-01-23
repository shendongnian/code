    public UserControl1()
    {
        InitializeComponent();
        var binding = new MultiBinding
        {
            Converter = new TextConverter(),
            Mode = BindingMode.TwoWay
        };
        binding.Bindings.Add(new Binding
        {
            Source = textBox1,
            Path = new PropertyPath("Text"),
            Mode = BindingMode.TwoWay
        });
        binding.Bindings.Add(new Binding
        {
            Source = textBox2,
            Path = new PropertyPath("Text"),
            Mode = BindingMode.TwoWay
        });
        SetBinding(TextProperty, binding);
    }
