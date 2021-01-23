    private void btnStart_Click(object sender, EventArgs e)
    {
    	if (btnStart.Text == "Start")
    	{
    		...
    	}
    	else
    	{
    		m_bgWorker.CancelAsync();
    	}
    }
    private void SearchFiles(string strPath, string strPattern)
    {
    	string strMessage = "Parsing directory " + strPath;
    	m_bgWorker.ReportProgress(0, strMessage);
    	foreach (string strFileName in Directory.GetFiles(strPath, strPattern))
    	{
    		if (m_bgWorker.CancellationPending)
    		{
    			return;
    		}
    		else
    		{
    			m_lstFiles.Add(strFileName);
    		}
    	}
    
    	foreach (string strDirName in Directory.GetDirectories(strPath))
    	{
    		if (m_bgWorker.CancellationPending)
    		{
    			return;
    		}
    		else
    		{
    			SearchFiles(strDirName, strPattern);
    		}
    	}
    }
