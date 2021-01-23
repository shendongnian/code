    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }     
   
        private void button1_Click(object sender, EventArgs e)
        {
            FileInfo info = new FileInfo("c:\\test.txt");
            if (info.Length > 0)  
            {           
                //Code for Redirection to New Form
            }
        }
    }
