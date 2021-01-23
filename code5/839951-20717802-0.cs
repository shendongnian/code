    public void Browser_LoadEnd(object sender, EventArgs e)
    {
        BeginInvoke(new Action(() =>
        {
             MyCefStringVisitor visitor = new MyCefStringVisitor(this, m_url);
             _cefGlueBrowser.Browser.GetMainFrame().GetSource(visitor);
             loaded = true;
        }));
    }
