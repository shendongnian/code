    public void LookForResultPages()
    {
        Int32 maxMilliSecondsToWait = 3 * 60 * 1000;
        bool processedPage = false;
        do
        {
            if ( CountProperties("InnerText", "Some text on most common page") > 0 )
            {
                ... process that page;
                processedPage = true;
            }
            else if ( CountProperties("InnerText", "Some text on another page") > 0 )
            {
                ... process that page;
                processedPage = true;
            }
            else
            {
                const Int32 pauseTime = 500;
                Playback.Wait(pauseTime); // In milliseconds
                maxMilliSecondsToWait -= pauseTime;
            }
        } while ( maxMilliSecondsToWait > 0 && !processedPage );
        if ( !processedPage )
        {
            ... handle timeout;
        }
    }
    public int CountProperties(string propertyName, string propertyValue)
    {
        HtmlControl html = new HtmlControl(this.myBrowser);
        UITestControlCollection htmlcol = new UITestControlCollection();
        html.SearchProperties.Add(propertyName, propertyValue, PropertyExpressionOperator.Contains);
        htmlcol = html.FindMatchingControls();
        return htmlcol.Count;
    }
