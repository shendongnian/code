    public partial class Form1 : Form
    {
        BindingList<string> list01 = new BindingList<string>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = list01;
            list01.Add("AAA");
            list01.Add("BBB");
            list01.Add("CCC");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (list01.Count >= 5)
                list01.RemoveAt(4);
            list01.Insert(0, DateTime.Now.ToString());
        }
    }
