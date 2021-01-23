    public partial class Form1 : Form
    {
        private Button button1 = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (button1 == null)
            {
                button1 = new Button();
                button1.Text = "New Button";
                button1.Location = new System.Drawing.Point(10, 10);
                button1.Size = new System.Drawing.Size(150, 30);
                button1.Click += new System.EventHandler(button1_Click);
                this.Controls.Add(button1);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked.");
        }
    }
