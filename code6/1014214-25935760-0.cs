    private ManualResetevent mre = new ManualResetEvent(false);
    void t2_Tick(object sender, EventArgs e)
    {
        string postVerifyHTML = string.Empty;
        try
        {
            postVerifyHTML = wb.Document.Body.InnerHtml;
        }
        // if page fails, restart
        catch
        {
            wb.Navigate(new Uri("http://www.website.com"), "_self");
        }
        if (postVerifyHTML.IndexOf("indentifier html") != -1)
        {
            NameSearchResults[nameCounter].Visited = true;
            nameCounter++;
            ResultFound = true;
            t2.Enabled = false;
            //Set the mre to unblock the blocked code
            mre.Set();
        }
        t2TimerCount++;
        if (t2TimerCount >= 100)
        {
            // TRY AGAIN
            wb.Navigate(new Uri("http://www.website.com"), "_self");
        }
    }
    protected void wb_SearchForm_DocumentCompleted(object sender, EventArgs e)
    {
        string pageHTML = wb.Document.Body.InnerHtml;
        // Look at the page with the name result
        if (pageHTML.IndexOf("Search Results: Verify") != -1)
        {
            //If the page has this input, a verification is available
            if (pageHTML.IndexOf("txtSSN") != -1)
            {
                HtmlElement txtSSN = wb.Document.GetElementById("txtSSN");
                txtSSN.SetAttribute("value", curSearchRecord.UniqueId.Replace("-", "").Replace(" ", ""));
                HtmlElement submitBtn = wb.Document.GetElementById("ibtnVerify");
                submitBtn.InvokeMember("click");
                t2.Enabled = true;
                //The code will block until Set() is called on mre
                mre.WaitOne();
                //The rest of your code here
    }
    
