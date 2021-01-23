    sCount = checkedListBox1.CheckedItems.Count;
    // Supposing that you could access your ProgressBar in this point
    pBar.Maximum = sCount; 
    pBar.Minimum = 0;
    for (int i = 0; i < sCount; i++)
    {
        backgroundWrkSendPOST.ReportProgress(i); 
    }
