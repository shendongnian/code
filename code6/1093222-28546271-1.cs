    namespace smallTesting
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
              InitializeComponent();
            }
            private void btnStart_Click(object sender, EventArgs e) //It should work on button click.
            {
                btnStart.Enabled = false;
                // Pass the reference of the instance of Form1 that you
                // want to update. Do not let the Testing class creates its
                // own instance of form1, instead use THIS ONE.
                Testing tst = new Testing(this);
            }
            ......
        }
    }
