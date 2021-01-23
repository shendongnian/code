    public partial class TextBoxItemsControlSample : Window
    {
        public TextBoxItemsControlSample()
        {
            InitializeComponent();
            DataContext = Enumerable.Range(0, 100).Select(x => "Text" + x.ToString());
        }
    }
