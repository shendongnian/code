    private void CurrentLoanOpened(object sender, EventArgs e) 
    {
        ThirdPartyDLL.CurrentLoan.LogEntryAdded += CurrentLoan_LogEntryAdded;
        ThirdPartyDLL.CurrentLoan.LogEntryChange += CurrentLoan_LogEntryChange;
    }
    
    private void CurrentLoan_LogEntryAdded(object sender, LogEntryEventArgs e)
    {
        //LogEntryAdded fired
        YourOptionalCommonMethodIfAny();
    }
    
    private void CurrentLoan_LogEntryChange(object sender, LogEntryEventArgs e)
    {
        //LogEntryChange fired
        YourOptionalCommonMethodIfAny();
    }
