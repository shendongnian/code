    void ShowWarningMessageDialog<T>(
        string infoMessage, 
        Action<T> retryAction, 
        T parameter)
    {
        // Do no work here; defer to other method.
        ShowWarningMessageDialog(infoMessage, ()=>{retryAction(parameter);});
    }
    void ShowWarningMessageDialog<T>(
        string infoMessage, 
        Action<T> retryAction)
    {
        // Do no work here; defer to other method.
        ShowWarningMessageDialog(infoMessage, retryAction, default(T));
    }
    void ShowWarningMessageDialog(
        string infoMessage, 
        Action retryAction)
    {
        // Actually do the work here. 
    }
