    public partial class Form1 : Form
        {
           int count = 0;
           int maxlimit=10000;
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                button1.Enabled = false;
                SetTimer(500);
            }
            private void SetTimer(int milliseconds)
            {            
                timer1.Interval = milliseconds;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
            }
            private void timer1_Tick(Object o, EventArgs e)
            {
                if (count < maxlimit)
                {
                    label1.Text = count.ToString();
                    count++;
                }
                else
                {
                    count = 0;
                    button1.Enabled = true;
                    label1.Text = "completed!";
                    timer1.Stop();
                    
                }
            }
