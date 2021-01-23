    public bool ShouldCloseApp { get; private set; }
    private RelayCommand<Window> _exitApplicationCommand;
    public RelayCommand<Window> ExitApplicationCommand
    {
        get
        {
            if (_exitApplicationCommand == null)
            {
                _exitApplicationCommand = new RelayCommand<Window>(exitApplicationCommand);
            }
            return _exitApplicationCommand;
        }
    }
    /// <summary>
    /// This closes a specified window.  If you pass the main window, then this application 
    /// will exit.  This is because the application shut down mode is set to OnMainWindowClose.
    /// </summary>
    /// <param name="window">The window to close.</param>
    private void exitApplicationCommand(Window window)
    {
        try
        {
            DialogService.ShowConfirmation(
                UIStrings.MainWindowViewModel_ExitProgramHeader,
                UIStrings.MainWindowViewModel_ExitProgramMessage,
                UIStrings.MainWindowViewModel_ExitProgramAcceptText,
                UIStrings.MainWindowViewModel_ExitProgramCancelText,
                (DialogResult result) =>
                {
                    if ((result.Result.HasValue) && (result.Result.Value))
                    {
                        if (ElectroTekManager.Manager.ConnectedElectroTek != null)
                        {
                            SendToStatusOperation operation = new SendToStatusOperation(ElectroTekManager.Manager.ConnectedElectroTek, (operationResult, errorMessage) =>
                            {
                                if (operationResult != FirmwareOperation.OperationResult.Success)
                                {
                                    log.Debug(string.Format("{0} {1}", CautionStrings.MainWindowViewModel_LogMsg_UnableToSendToStatus, errorMessage));
                                }
                                else if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    log.Debug(errorMessage);
                                }
                                Application.Current.Dispatcher.Invoke(new Action(() => closeApp(window)));
                            });
                            operation.Execute();
                        }
                        else
                        {
                            closeApp(window);
                        }
                    }
                });
        }
        catch (Exception ex)
        {
            log.Debug(CautionStrings.MainWindowViewModel_LogMsg_FailedToShowConfirmation, ex);
        }
    }
    /// <summary>
    /// Closes the application.
    /// </summary>
    /// <param name="window">The window.</param>
    private void closeApp(Window window)
    {
        ShouldCloseApp = true;
        Dispose();
        Application.Current.Shutdown();
    }
