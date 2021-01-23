    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(Application.StartupPath + "\\F2.exe");
    
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
    
            process.OutputDataReceived  += (datasender, outputLine) => {
                if (outputLine.Data != null)
                {
                    Console.WriteLine("Incoming data" + outputLine.Data);
                }
            };
        }  
    }
    
