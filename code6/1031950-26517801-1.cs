      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
        }
    
        [DllImport("kernel32.dll", 
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
    
        [DllImport("kernel32", SetLastError = true)]
        static extern bool AddConsoleAlias(string Source, string Target, string ExeName);
    
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();
    
        private void btnAddAlias_Click(object sender, EventArgs e)
        {
          AllocConsole();
    
          if (AddConsoleAlias(txbSource.Text, txbTarget.Text, "cmd.exe"))
          {
            MessageBox.Show("Success");
          }
          else
          {
            MessageBox.Show(String.Format("Problem occured - {0}", GetLastError()));
          }
        }
      }
