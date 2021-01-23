    private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        MessageBox.Show("Hi, I'm closing!");
        e.Cancel = true;
    }
