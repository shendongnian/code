    private void btnPost_Click(object sender, EventArgs e)
    {
    	for (int i = 0; i < lstgroupsbox.Items.Count; i++)
    	{
    		_jobQueue.Enqueue(lstgroupsbox.Items[i].ToString(),
    			"amine",
    			txtStatus.Text,
    			"googl",
    			txtLink.Text,
    			"seach",
    			txtImagePath.Text);
    	}
        _jobTimer.Start();
    }
