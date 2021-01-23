    /// <summary>
    /// Interaction logic for MultiColumnComboBox.xaml
    /// </summary>
    public partial class MultiColumnComboBox : UserControl
    {
        /// <summary>
        /// This creates the dependency property for the collection to display.
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IList<Customer>), typeof(MultiColumnComboBox));
        /// <summary>
        /// This property gets you to the collection that's being displayed.
        /// </summary>
        public IList<Customer> ItemsSource
        {
            get { return (IList<Customer>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public MultiColumnComboBox()
        {
            InitializeComponent();
        }
    }
