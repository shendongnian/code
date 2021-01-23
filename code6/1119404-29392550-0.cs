     public partial class Form2 : Form
    {
        public Form2(Form1 frm1)
        {
            InitializeComponent();
            Form1Prop = frm1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1Prop.SetFilepath("HIHI");
            Form1Prop.DataGridPropGrid.Rows.Add("HIH", "KI", "LO", "PO");
        }
        public Form1 Form1Prop { get; set; }
    }
    
    
     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(this);
            frm2.Show();
        }
        public void SetFilepath(string filepath)
        {
            textBox1.Text = filepath;
        }
        public DataGridView DataGridPropGrid
        {
            get
            {
                return dataGridView1;
            }
        }
    }
