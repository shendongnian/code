    namespace TEST_CSA
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 sub = new Form2();
                sub.Show(this);
                this.Enabled = false;
                sub.RegisterParent(this);
                for (int x = 1; x <= 5; x++)
                {
                    string[] row;
                    row = new string[] { "1", "2" };
                    sub.DGVFile.Rows.Add(row);
                }
            }
    
        }
    }
