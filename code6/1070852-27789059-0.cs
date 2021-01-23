    Dispatcher.BeginInvoke(new Action(() =>
    {
        if (txtContent.Text != null)
        {
            txtContent.Text = txtContent.Text + Environment.NewLine + " >> " + readData;
        }
    });
