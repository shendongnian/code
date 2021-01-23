    /// <summary>
    /// Navigate to a url for your test
    /// </summary>
    /// <param name="url">String of where you want the browser to go to</param>
    public void GoToUrl(string url)
    {
        this.driver.Url = url;
    }
    
    /// <summary>
    /// Navigate to a url for your test
    /// </summary>
    /// <param name="url">Uri object of where you want the browser to go to</param>
    public void GoToUrl(Uri url)
    {
        if (url == null)
        {
            throw new ArgumentNullException("url", "URL cannot be null.");
        }
    
        this.driver.Url = url.ToString();
    }
