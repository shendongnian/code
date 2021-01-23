    public partial class Form1 : Form
    {
        public int a { get; set; }
        public int b { get; set; }
    
        public Form1()
        {
            InitializeComponent();
            b = 10;
            typeof(Form1).GetProperty("b").SetValue(this, 5, null);
            Text = b.ToString();
        }
    }
