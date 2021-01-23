    public Publisher(...)
    {
       ...
       PrintResultEvent printResultEvent = this.eventAggregator.GetEvent<PrintResultEvent>();
       printResultEvent.Subscribe(PrintResultEventHandler);
    }
    public void Execute(object parameter)
    {
        var arg = new PrintCustomerAccountSummaryReportRequestedEventArgument  { Customer = _viewModel.Customer, StartDate = _viewModel.ReportStartDate, EndDate = _viewModel.ReportEndDate };
        EventManager.Instance.GetEvent<PrintCustomerAccountSummaryReportRequestedEvent>().Publish(arg);
        // Wait until something has handled the event
        // then continue on and execute code. Result will be handled in following EventHandler.
    }
    private void PrintResultEventHandler(PrintCustomerAccountSummaryReportRequestedEventArgument result)
    {
       // Get print result and finish job accordingly.
    }
