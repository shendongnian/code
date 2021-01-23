    interface IWorkNotifier
    {
        void ShowError(string text);
    }
    public class ProcessingWindow: IWorkNotifier
       ...
    public void ShowError(string text)
    {
        Application.Current.Dispatcher.Invoke((Action)(() => DoShowError(text)));
    }
    private void DoShowError(string text)
    {
        SomethingIsWrongDialog dialog = new SomethingIsWrongDialog();
        dialog.ShowDialog();
    }
    void ProcessingProgressWindow_Loaded(object sender, RoutedEventArgs e)
        {
            m_backGroundWorker.RunWorkerAsync(this);
        }
    private void m_backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        var arg = (IWorkNotifier)e.Argument;
        foreach (ProcessingJob job in m_processingJobs)
        {
            if (job.somethingIsWrong)
            {
                arg.ShowError("shit happened");
            }
        }
    }
