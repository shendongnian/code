    using (BackgroundWorker bgw = new BackgroundWorker())
    {
        bgw.DoWork += bgw_DoWork;
        bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
        
        this.tsslDbError.ForeColor = System.Drawing.Color.Black;
        tsslDbError.Text = "Please wait... While connecting to iReg Database.";
        bgw.RunWorkerAsync();
    }
