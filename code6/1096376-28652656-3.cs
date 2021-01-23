    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding binding = new Binding();
            binding.Source = slider2;
            binding.Path = new PropertyPath(Slider.ValueProperty);
            ValidationParameters validationParams = (ValidationParameters)Resources["validationParams1"];
            BindingOperations.SetBinding(validationParams, ValidationParameters.NumberCombineToProperty, binding);
        }
    }
