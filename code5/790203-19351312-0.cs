    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
         
            var res = f2.ShowDialog();
            
            if (res == DialogResult.OK)
            {
                var f3 = new Form3();
                this.Visible = false;
                f3.ShowDialog();
                this.Close();
            }
        }
    }
