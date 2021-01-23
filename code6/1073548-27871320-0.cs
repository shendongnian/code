    protected override void OnFormClosing(FormClosingEventArgs e)
    {
    	base.OnFormClosing(e);
    	if (e.CloseReason != CloseReason.WindowsShutDown && !UserDidQuit)
    	{
    		Application.Exit();
    	}
    }
