    private void windowClosing(object sender, System.ComponentModel.CancelEventArgs e)
    {
       Properties.Settings.Default.FirstRun = false;
       Settings.Default.Save();
    }
