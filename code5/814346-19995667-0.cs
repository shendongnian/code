    public partial class Form2 : Form
    {
        string sname;
    
        public Form2(string name, string id, Form a)
        {
            sname = name;
                
            InitializeComponent();
        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = sname; // Set your login name on label
        }
    }
