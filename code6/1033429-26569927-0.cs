    public partial class MainWin : Form
        {
            public MainWin()
            {
                InitializeComponent();
            }
    
            static System.Timers.Timer timer;
    
            private void buttonStartNFC_Read_Click(object sender, EventArgs e)
            {
                try
                {
                    timer = new System.Timers.Timer(2000)); \\ <- 2000 milliseconds is 2 seconds
                    timer.Elapsed += new ElapsedEventHandler(request);
    
                    timer.Enabled = true;
                    buttonNFC.Enabled = false; \\ u probably want to disable the button
                }
                catch (Exception ex)
                {
                    print("Exception in :" + ex.Message);
                }
            }
