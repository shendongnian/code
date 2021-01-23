    private void videoMediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
    {
        // Check the event arguments => e
    
        // get HRESULT from event args 
        string hr = GetHresultFromErrorMessage(e);
    
        // Handle media failed event appropriately 
    }
    
    private string GetHresultFromErrorMessage(ExceptionRoutedEventArgs e)
    {
        String hr = String.Empty;
        String token = "HRESULT - ";
        const int hrLength = 10;     // eg "0xFFFFFFFF"
    
        int tokenPos = e.ErrorMessage.IndexOf(token, StringComparison.Ordinal);
        if (tokenPos != -1)
        {
            hr = e.ErrorMessage.Substring(tokenPos + token.Length, hrLength);
        }
    
        return hr;
    }
