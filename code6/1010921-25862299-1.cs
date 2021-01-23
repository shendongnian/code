    public partial class MyComboBox<T> : UserControl where T: class
    {
        public MyComboBox()
        {
            InitializeComponent();
        }
        public void Add(T item)
        {
            comboBox1.Items.Add(item);
        }
        public IEnumerable<T> Items
        {
            get { return comboBox1.Items.Cast<T>(); }
        }
    }
