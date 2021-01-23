    namespace SampleStartStop
    {    
        public partial class Form1 : Form
        {   
            Thread Thread1;
            public Form1()
            {
                InitializeComponent();            
            }
    
            private void btnStart_Click(object sender, EventArgs e)
            {
                Thread1 = new Thread(SlowFunction);            
                Thread1.Start();                        
            }
    
            private void btnStop_Click(object sender, EventArgs e)
            {
                Thread1.Abort();
                MessageBox.Show("Processing canceled");
            }
            public void SlowFunction()
            {
                var end = DateTime.Now + TimeSpan.FromSeconds(10);
                while (DateTime.Now < end)
                { }
                MessageBox.Show("Process finished");
            }
    
        }
    }
