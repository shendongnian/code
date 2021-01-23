    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private String lastRunDate = "";
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                timer1.Interval = 1000;
                timer1.Enabled = true;
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                if (lastRunDate != System.DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    String str = System.DateTime.Now.ToString("h:mm tt");
                    if (str.Equals("1:00 AM"))
                    {
                        lastRunDate = System.DateTime.Now.ToString("yyyy-MM-dd");
                        MessageBox.Show(str);                    
                    }
                }
            }
        }
    }
