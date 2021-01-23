        System.ComponentModel.DependencyPropertyDescriptor descriptor;
        public MainWindow()
        {
            InitializeComponent();
            descriptor = System.ComponentModel.DependencyPropertyDescriptor.FromProperty(TextBox.TextProperty, typeof(TextBox));
            descriptor.AddValueChanged(txtbox1, TxtChanged);
            descriptor.AddValueChanged(txtbox2, TxtChanged);
            
        }
        public void TxtChanged(object sender, EventArgs ea)
        {
            Debug.WriteLine("change from " + ((FrameworkElement)sender).Name);
        }
