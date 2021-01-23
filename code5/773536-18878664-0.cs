    namespace WpfApplication1
    {
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Page1.onNameSend += Page1_onNameSend;
        }
        void Page1_onNameSend(string Name)
        {
            Console.WriteLine(Name);
        }
    }
    }
