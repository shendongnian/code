    private void VideoWorker_WorkCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
            MessageBox.Show(e.Error.ToString());
        else
            MessageBox.Show("Nothing to see here. Move along.");
    }
