    public partial class Form1 : Form
    {
        private ADCs ADCsdiag = new ADCs();
        public Form1()
        {
            InitializeComponent();
            ADCsdiag.Closing += (sender, eventArgs) =>
                {
                    eventArgs.Cancel = true;
                    ((ADCs)sender).Hide();
                };
        }
        private void pictureBox18_Click(object sender, EventArgs e)
        {
            ADCsdiag.Show();
        }
    }
