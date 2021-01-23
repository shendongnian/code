    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.X = this.Location.X;
            Settings.Y = this.Location.Y;
        }
    }
