    /// <summary>
    /// Show a error dialog box
    /// </summary>
    /// <param name="errorDialogText"></param>
    public void ShowErrorDialog(String errorDialogText)
    {
        if (!Visible || !IsMobile())
        {
            ErrorDialog.Show(errorDialogText);
        }
        else
        {
            ShowStatus(errorDialogText);
        }
    }
