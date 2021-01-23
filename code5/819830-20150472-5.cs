    private void RegisterAnalyticsSettingsScript()
    {
        string script = GoogleAnalyticsConfiguration.GetAnalyticsSettingsScript();
        if (!string.IsNullOrEmpty(script))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "AnalyticsSettings", script, true);
        }
    }
