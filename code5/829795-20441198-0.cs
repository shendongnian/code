    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            /*Fetch data from LastUser Table*/
            /*Display Data on Form*/
            // now set Timer to wait for 5 seconds
            timer1.Interval = 5000;//5 seconds
            timer1.Tick+=timer1_Tick;
            timer1.Start();
        }
       private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Form2 mainform = new Form2();
            this.Hide();           
            mainform.Show();
        }
    }
