    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string exeName = "ping.exe";
            string[] parameters = new string[] { "127.0.0.1", "-t" };
            Process externalProcess = new Process();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                CaptureConsole RunConsole = new CaptureConsole(exeName, parameters, ShowStdOutput, ShowStdError);
                externalProcess = RunConsole.Run(450);
                this.InvokeEx(x => x.listBox1.Items.Add(String.Format("Process Started: {0}", externalProcess.StartTime)));
            }
            
            void ShowStdOutput(object sender, DataReceivedEventArgs e)
            {
                try
                {
                    if (e.Data != null && !externalProcess.HasExited)
                        this.InvokeEx(x => x.listBox1.Items.Add(e.Data));
                }
                catch { };
            }
    
            private void ShowStdError(object sender, DataReceivedEventArgs e)
            {
                try
                {
                    if (e.Data != null && !externalProcess.HasExited)
                        this.InvokeEx(x => x.listBox1.Items.Add(e.Data));
                }
                catch { };
            }
        }
    }
