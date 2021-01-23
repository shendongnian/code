    public void OpenKioskBrowser(string URL)
    {
        Task.Run(() =>
        {
            SHDocVw.InternetExplorer ie = new SHDocVw.InternetExplorer();
            ie.Navigate(URL);
            ie.ToolBar = 0;
            ie.AddressBar = false;
            ie.Width = 350;
            ie.Height = 200;
            ie.Visible = true;
        });
    }
