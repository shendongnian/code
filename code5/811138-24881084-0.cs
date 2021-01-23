    /// <summary>
    /// Sets needed values
    /// </summary>
    /// <param name="clientId">The ClientId from the application</param>
    /// <param name="redirectUri">The RedirectUri where the browser has to be send.</param>
    /// <param name="resource">The source you want to access</param>
    public OneDriveConnection(string clientId, string clientSecret, string redirectUri, string resource)
    {
        this._clientId = clientId;
        this._redirectUri = Uri.EscapeDataString(redirectUri);
        this._resource = Uri.EscapeDataString(resource);
        this._clientSecret = clientSecret;
    }
