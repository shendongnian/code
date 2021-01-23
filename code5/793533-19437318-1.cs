    ...
        if (bw.IsBusy != true)
            {
                // Start the ReadAll parameters thread
                btnReadAll.Text = "Cancel Read";
                btnWriteAll.Enabled = false;
                bw.RunWorkerAsync(new ReadAllArguments(true, this));
            }
    ...
