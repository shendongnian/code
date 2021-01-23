    try        
    {
        if((bg1 == null)
        {
            InitializeBackgroundWorker();
        }
        if ((bg1 != null) && (!bg1.IsBusy))
        {
            bg1.RunWorkerAsync(myp);
        }
        if ((bg2 != null) && (!bg2.IsBusy))
        {
            bg2.RunWorkerAsync(mya);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
