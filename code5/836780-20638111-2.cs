    public partial class LabeledComboBox : UserControl
    {
        private static readonly DependencyProperty ItemConverterProperty =
            DependencyProperty.Register(
                "ItemConverter", typeof(IValueConverter), typeof(LabeledComboBox));
        public IValueConverter ItemConverter
        {
            get { return (IValueConverter)GetValue(ItemConverterProperty); }
            set { SetValue(ItemConverterProperty, value); }
        }
        public LabeledComboBox()
        {
            InitializeComponent();
            var converter = (InternalItemConverter)Resources["InternalItemConverter"];
            converter.LabeledComboBox = this;
        }
    }
