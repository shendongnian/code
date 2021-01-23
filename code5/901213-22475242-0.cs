    return miniAdminService.GetServiceVersionAsync().ContinueWith(t =>
    {
        if (t.Exception != null)
        {
            // The Admin Service seems to be unavailable
        }
        else
        {
            // The Admin Service is available
        }
    }, TaskContinuationOptions.ExecuteSynchronously);
