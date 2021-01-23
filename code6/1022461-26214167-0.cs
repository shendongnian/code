    I played a while, here is the solution:
    
    namespace DataTimePicker1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
            {
                DateTime dt = dateTimePicker1.Value;
                
                if (dt.Hour == 0 && dt.Minute == 0 &&
                    dt.Second < 10)
                {
                    int inc = 10 - dt.Second;
                    dateTimePicker1.Value = dateTimePicker1.Value.AddSeconds(inc);
                }
            }
        }
    }
