    public partial class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            InitializeComponent();
        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property.Name.Contains("Text")) 
            {
                // The Text property value has changed
            }
        }
    }
