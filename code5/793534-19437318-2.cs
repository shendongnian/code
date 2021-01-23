    private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            DoUIWorkHandler DoReadClick;
            DoUIWorkHandler DoWriteClick;
    
            int CurrentControlCount = 1;
            string StatusText = "";
            int ProgressValue = 0;
            ReadAllArguments arguments = e.Argument as ReadAllArguments;
            if (this != arguments.ListForm)
              return;
    
            ...
    
                            if (arguments.Read)
                            {
                                DoReadClick = c.btnRead.PerformClick;
                                c.Invoke(DoReadClick);
                            }
                            else
                            {
                                DoWriteClick = c.btnWrite.PerformClick;
                                c.Invoke(DoWriteClick);
                            }
           ...
