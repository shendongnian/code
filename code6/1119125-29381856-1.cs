    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Form[] t = new Form[3];
            for (int count = 0; count < t.Length; count++)
            {
                t[count] = new Form();
                t[count].Show();
            }
        }
    }
