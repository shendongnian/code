    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Class1();
        }
    }
    public class Class1
    {
        public static string j = "houmaaaaaaaaaaaani";
        public string J { get { return j; } set { j = value; } }
    }
