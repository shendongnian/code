    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if(!m_processStarted)
    	{
    	    string message = DateTime.Now.ToString("T") + " - Start processing ... ";
    	    txtboxLogger.AppendText(message + Environment.NewLine);		
            m_processStarted = true;
    	}
    }
