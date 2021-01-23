    private void btnCopyItems_Click(object sender, EventArgs e)
    {
      // Set the progressBar1.Maximum here before we call the background worker
      // This is what caused your exception, since it is an UI element that you are trying to change
      // inside your BackgroundWorker thread
      progressBar1.Maximum = 100;             // % based (Could be set onces and always left at 100)
      progressBar1.Maximum = itemscoll.Count; // x/y based
      // Either we use a percentage based progressbar or an x/y progressbar.
      // !!!! Choose one and use the appropriate values for it !!!!
      
      backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      try
      {
        WorkerItem workerItem = (WorkerItem)e.Argument;
        Helper.siteName = txtSite.Text;
        {
          // Variable for our progress calculation
          double curProgress; // % based
          
          // Since we need to report progress, let us use a for-loop instead of a foreach-loop
          for (int i = 0; i < itemscoll.Count-1; i++)
          {
            SPListItem sourceItem = itemscoll[i];
            date = sourceItem["Date_x0020_Created"].ToString();
            if (!string.IsNullOrEmpty(date))
            {
              workerItem.CopyItem(sourceItem, Helper.destinationListName, Helper.destServerURL);
            }
            
            // Calculate the current progress and call the ReportProgress event of our BackgroundWorker
            curProgress = ((double)i / (double)itemscoll.Count) * 100;                // % based
            ((BackgroundWorker)sender).ReportProgress(Convert.ToInt32(curProgress));  // % based
            
            // If we only go x/y progress based, then just send back our current state
            ((BackgroundWorker)sender).ReportProgress(0, i);  // x/y based
          }
        }
        Cursor.Current = Cursors.Default;
        MessageBox.Show(string.Format("Items Copied {0}", Helper.ItemsCopied.ToString()));
      }
      catch (Exception ex)
      {
        Helper.LogtoList("Main Function ", string.Format("{0} Message {1} Source {2} Stack trace {3}", ex.InnerException.ToString(), "Message " + ex.Message + "Source" + ex.Source + "Stack trace" + ex.StackTrace));
      }
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      // % based
      progressBar1.Value = e.ProgressPercentage;
      this.Text = e.ProgressPercentage.ToString();
      
      // x/y based
      progressBar1.Value = Convert.ToInt32(e.UserState);
      this.Text = Convert.ToInt32(e.UserState).ToString();
    }
    
