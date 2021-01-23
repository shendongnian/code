    public partial class Form1 : Form
    {
        Lazy<MyClass> obj = new Lazy<MyClass>();
    
        public Form1()
        {
            InitializeComponent();
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            obj.Value.StartWork();
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            obj.Value.StopWork();
        }
    }
