    public partial class Window1 : UserControl
    {
        public Window1()
        {
            InitializeComponent();
            MyStrings = new List<string>(new[] { "A", "B", "C", "D" });
            DataContext = this; // Rule #2
        }
    
        public List<string> MyStrings { get; set; } // Rule #1
    }
