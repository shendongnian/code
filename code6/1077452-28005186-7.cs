    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string fileName) : this()
        {
            if (fileName == null)
                return;
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Invalid file name.");
                return;
            }
            textBox1.Text = File.ReadAllText(fileName);
        }
    }
