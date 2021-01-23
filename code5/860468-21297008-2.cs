     public partial class Form1 : Form
    {
        private TextBox[,] textboxes;
    
        public Form1()
        {
            InitializeComponent();
            Initialize();
        }
    
        private void Initialize()
        {
            textboxes = new TextBox[,] { { box00, box01 }, { box10, box11 } };
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
    
        }
    }
