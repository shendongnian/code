    public MyUserControl()
    {
        InitializeComponent();
        
        // Set your datacontext.
        var binding = new Binding("SomeVMProperty");
        binding.Source = this.DataContext;
        SetBinding(MyDependencyProperty, binding);
    }
