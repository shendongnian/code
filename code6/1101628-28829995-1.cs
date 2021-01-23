    private void BackgroundWorker1OnDoWork(object sender, DoWorkEventArgs e)
    {
    	WorkerItem workerItem = (WorkerItem)e.Argument;
    
    	for (int i = 0; i < workerItem.SPListItems.Count(); i++)
    	{
            // CopyListItem is doing the copy for one item.
    		CopyListItem(workerItem.SPListItems[i], workerItem.DestinationListName, workerItem.DestinationServerURL);
    		((BackgroundWorker)sender).ReportProgress(i + 1);
    	}
    }
