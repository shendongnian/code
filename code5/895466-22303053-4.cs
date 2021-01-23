    private void updateOutputArea(TaskScheduler uiScheduler)
    {
        Task.Factory.StartNew(() =>
        {
            tb_output.AppendText(cmdOutput + "\r\n" + cmdErrOutput + "\r\n");
            cmdOutput.Clear();
            cmdErrOutput.Clear();
        }, System.Threading.CancellationToken.None, TaskCreationOptions.None, uiScheduler);
        }
        
