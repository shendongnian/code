    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                Form2 F2 = new Form2(this.Handle);
                F2.Show();
            }
        }
    }
