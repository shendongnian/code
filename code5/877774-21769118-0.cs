    private void CallWithSuccessHandler(System.Action action, System.Action onSuccess = null, System.Action onFailure = null)
    {
        try
        {
            action();
            onSuccess();
        }
        catch (Exception ex)
        {
            if (onFailure != null) onFailure();
            throw;
        }
    }
