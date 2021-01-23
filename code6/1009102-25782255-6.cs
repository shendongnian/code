    /// <summary>
    /// Refresh the browser
    /// </summary>
    public void Refresh()
    {
        // driver.SwitchTo().DefaultContent();
        this.driver.InternalExecute(DriverCommand.Refresh, null);
    }
