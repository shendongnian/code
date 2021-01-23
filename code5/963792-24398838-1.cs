    public partial class Form1 : Form
    {
        int var1 = 0;
        Glob glob;
     
        public Form1()
        {
            InitializeComponent();
            glob = new Glob(this);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            glob.Func1();
        }
    }
