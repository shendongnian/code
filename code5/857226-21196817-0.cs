    void closeButtonClicked(object sender, EventArgs e)
    {
      if(backgroundWorker.IsBusy)
      {
        var result = MessageBox.Show("...");
        
        if(result == DialogResult.OK)
          backgroundWorker.CancelAsync();
    
        return;
      }
      
      this.Close();
    }
