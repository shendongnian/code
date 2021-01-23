    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Spammer//your own namesapce
    {
        public partial class Form1 : Form
        {
            int delayInMilliseconds, y = 1;
            private Timer timer1;
    
            public Form1()
            {
                InitializeComponent();
                //StartTimerWithThreading();       
                SetupTimer();
            }
    
            void StartTimerWithThreading()
            {
                Task.Factory.StartNew(() =>
                    {
                        SetupTimer();
                    });
            }
    
            void SetupTimer()
            {
                timer1 = new Timer();//Assume system.windows.forms.timer
                textBox2.Text = "10";//new delay
                timer1.Tick += timer1_Tick;//handler
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                delayInMilliseconds = int.Parse(textBox2.Text);
                timer1.Interval = delayInMilliseconds;
                timer1.Enabled = true;
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                timer1.Enabled = false;
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                String textt = textBox1.Text;
                SendKeys.SendWait(textt);
            }
    
        }
    }
