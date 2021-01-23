    public partial class Form1 : Form
    {    
      public Form1()
      {
        InitializeComponent();      
      }
      void OnStateChanged(DriveHelper.StateChangedEventArgs e)
      {
        // do your work here
        MessageBox.Show(string.Format("Drive: {0} => e.Ready: {1}, DriveInfo.IsReady: {2}", e.Drive, e.Ready, new DriveInfo(e.Drive).IsReady));
      }    
      protected override void WndProc(ref Message m)
      {
        DriveHelper.QueryDeviceChange(m, OnStateChanged);
        base.WndProc(ref m);
      }      
    }
