    /// <summary>
    /// Pastes the SecurityPermissions collection from the computer clipboard to the currently selected User.
    /// </summary>
    public ICommand PasteUserSecurityPermissions
    {
        get { return new ActionCommand(action => ((SecurityViewModel)ViewModel).
    PasteSecurityPermissions(ClipboardManager.GetClipboardSecurityPermissions()), 
    canExecute => ClipboardManager.HasClipboardGotDataFormat("SecurityPermissions")); }
    }
