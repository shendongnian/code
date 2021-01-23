    public partial class Main : Form
    {
        private const string PATH = "C:\\person.txt";
        public Main()
        {
            InitializeComponent();
            var lines = File.ReadLines(PATH);
            var line = lines.FirstOrDefault();
            if (line == null)
                return;
            var parts = line.Split(':');
            if (parts.Length != 2)
                return;
            textBox1.Text = parts[0];
            textBox2.Text = parts[1];
        }
    }
