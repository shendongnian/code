    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Thread.Sleep(Environment.TickCount%1500); //--simulate variables initialization
        }
    }
