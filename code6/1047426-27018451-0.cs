    public partial class Main : Form
    {
        private const string PATH = "C:\\person.txt";
        public Main()
        {
            InitializeComponent();
            // read lines from file at specified path
            var lines = File.ReadLines(PATH);
            
            // take first line from aquired collection
            var line = lines.FirstOrDefault();
            if (line == null)
                return;
            
            // split string to first and last names
            var parts = line.Split(':');
            if (parts.Length != 2)
                return;
            // send them to textBox.Text property
            textBox1.Text = parts[0];
            textBox2.Text = parts[1];
        }
    }
