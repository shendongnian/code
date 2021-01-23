    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PermissionDialog.Show(IntPtr.Zero, @"d:\temp\killroy_was_here.png");
        }
    }
