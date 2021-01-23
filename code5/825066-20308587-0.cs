    public partial class Form1 : Form
        {
            int count = 0;
            string text1 = "this is a scrolling text";
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();               
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                button1.Enabled = false;
                textBox1.ReadOnly = true;
                SetTimer(500);
            }
            private void SetTimer(int milliseconds)
            {            
                timer1.Tick+=new EventHandler(timer1_Tick);
                timer1.Interval = milliseconds;        
                timer1.Start();
            }
            private void timer1_Tick(Object o, EventArgs e)
            {
                if (count < text1.Length)
                {
                    textBox1.Text += text1[count];
                    count++;
                }
                else
                {
                    timer1.Stop();
                    button1.Enabled = true;
                    textBox1.ReadOnly = false;
                }
            }
        }
