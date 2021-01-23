    void ReportingClick(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start("http://www.google.ca");
        System.Threading.Thread.Sleep(1000);
        System.Diagnostics.Process.Start("http://www.gmail.com");
        System.Threading.Thread.Sleep(1000);
        System.Diagnostics.Process.Start("http://www.stackoverflow.com");
    }
