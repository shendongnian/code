    public partial class Form1 : Form
    {
        Form2 f2;
        System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
            tmr.Interval = 100;
            tmr.Enabled = false;
            tmr.Tick += delegate (object sender, EventArgs e) {
                tmr.Stop();
                this.IsMdiContainer = false;
            };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (f2 != null)
            {
                MessageBox.Show("Close form!");
                return;
            }
            f2 = new Form2();
            f2.FormClosed += delegate(object sender2, FormClosedEventArgs e2) { 
                f2 = null; 
            };    
            if (radioButton1.Checked == true)
            {
                this.IsMdiContainer = true;
                f2.FormClosed += delegate(object sender3, FormClosedEventArgs e3) { 
                    tmr.Start();
                };    
                f2.MdiParent = this;
            }
            f2.Show();
        }
    }
