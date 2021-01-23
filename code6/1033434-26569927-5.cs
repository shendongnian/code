    using System.Timers;
    public partial class MainWin : Form
        {
            public MainWin()
            {
                InitializeComponent();
            }
    
            Timer nfcTimer;
    
            private void buttonStartNFC_Read_Click(object sender, EventArgs e)
            {
                try
                {
                    nfcTimer = new Timer(2000)); \\ <- 2000 milliseconds is 2 seconds
                    nfcTimer.Elapsed += new ElapsedEventHandler(readCard);
                    nfcTimer.Enabled = true;
                    buttonNFC.Enabled = false; \\ u probably want to disable the button
                }
                catch (Exception ex)
                {
                    print("Exception in :" + ex.Message);
                }
            }
