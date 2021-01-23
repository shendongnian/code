     static class Program
    {
    	[STAThread]
    	static void Main()
    	{
    		if (!SingleInstance.Start()) {
    			SingleInstance.ShowFirstInstance();
    			return;
    		}
		
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		try {
			MainForm mainForm = new MainForm();
			Application.Run(mainForm);
		} catch (Exception e) {
			MessageBox.Show(e.Message);
		}
		
		SingleInstance.Stop();
	}
    } 
    //And secondly within your main form, the following code must be added:
    
    protected override void WndProc(ref Message message)
    {
    	if (message.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE) {
    		Show
    Window();
    	}
    	base.WndProc(ref message);
    } 
    
    public void ShowWindow()
    {
    	// Insert code here to make your form show itself.
    	WinApi.ShowToFront(this.Handle);
    }
     
