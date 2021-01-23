    public partial class Form1 : Form
    {
        private System.Diagnostics.Process _process;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            if (_process == null || _process.HasExited)
            {
                _process = new Process();
            }
            else
            {
                _process.Kill();
                _process = null;                
                button10.Text = "Scan";
    
                return;
            }
    
            int port = (int)numericUpDown2.Value;
            string path = Directory.GetCurrentDirectory();
            string strCommand = path + "/SystemFiles/nikto/nikto.bat";
            string host = textBox5.Text;
            Console.WriteLine(strCommand);
            richTextBox5.Text += "Starting Nikto Vulnerability Scan On " + host + " On Port " + port + System.Environment.NewLine;
    
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = strCommand,
                Arguments = "-h " + host + " -port " + port + textBox6.Text
            };
            
            _process.StartInfo = startInfo;
            _process.Start();
            richTextBox5.Text += "Vulnerability Scan Started On " + host + " On Port " + port + System.Environment.NewLine;
            button10.Text = "Cancel";
        }
    }
