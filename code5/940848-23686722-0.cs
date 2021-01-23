    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1] == "-e") Text = "Elevated";
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Application.ExecutablePath,
                    Arguments = "-e",
                    Verb = "runas",//-Admin.
                }
            };
            process.Start();
        }
    }
