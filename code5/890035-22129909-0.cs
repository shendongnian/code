    public MainWindow()
    {
       InitializeComponent();
       VM viewModel = new VM();
       DataContext = viewModel;
       Binding binding = new Binding("ControlText") { Source = this };
       BindingOperations.SetBinding(viewModel, VM.TextProperty, binding);
    }
