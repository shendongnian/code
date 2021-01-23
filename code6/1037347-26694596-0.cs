    public partial class MainWindow : Window
    {
        private string TextBlockPreviousState = "";
        public MainWindow()
        {
            InitializeComponent();
            ButtonStatusTextBlock.Text = "foo";
        }
        private void StoreAndUpdate()
        {
            TextBlockPreviousState = ButtonStatusTextBlock.Text;
            ButtonStatusTextBlock.Text = "Button Down";
        }
        private void Restore()
        {
            ButtonStatusTextBlock.Text = TextBlockPreviousState;
        }
        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            StoreAndUpdate();
        }
        private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Restore();
        }
    }
