    public partial class Form1 : Form
    {
        public Form1(string fileName)
        {
            InitializeComponent();
            if (fileName != "")
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                using (var sr = new StreamReader(fs)) textBox1.Text = sr.ReadToEnd();
        }
    }
