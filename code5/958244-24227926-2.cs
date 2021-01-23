     public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateList();
        }
        private void PopulateList()
        {
            for (int i = 0; i < 10; i++)
            {
                listBox1.Items.Add(i);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.RemoveAt(0);
                progressBar1.PerformStep();
                groupBox1.Text = listBox1.Items.Count.ToString();
            }
            else
            {
                timer1.Enabled = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Tick += timer1_Tick;
            timer1.Enabled = true;
            timer1.Interval = 500;
            progressBar1.Enabled = true;
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Value = 0;
            progressBar1.Maximum = listBox1.Items.Count;
            progressBar1.Step = 1;
        }
    }
