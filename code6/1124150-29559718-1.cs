    public class Resources
    {
        public string SlideToCollect { get { return "i'am SlideToCollect"; } }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindingExpression be = Slide.GetBindingExpression(TextBlock.TextProperty);
        }
    }
