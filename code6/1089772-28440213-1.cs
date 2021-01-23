    private void UpdateGUIAfterTableSend(String listboxVal)
    {
        ExceptionLoggingService.Instance.WriteLog("Reached frmMain.UpdateGUIAfterTableSend");
        try
        {
            BindingSource bs = listBoxWork.DataSource as BindingSource;
            for (int i = bs.Count - 1; i >= 0; --i)
            {
                if (bs[i].ToString().Contains("Test"))
                {
                    bs.RemoveAt(i);
                }
            }
        }
        catch (Exception ex)
        {
            String msgInnerExAndStackTrace = String.Format("{0}; Inner Ex: {1}; Stack Trace: {2}", ex.Message, ex.InnerException, ex.StackTrace);
            ExceptionLoggingService.Instance.WriteLog(String.Format("From frmMain.UpdateGUIAfterTableSend: {0}", msgInnerExAndStackTrace));
        }
    }
