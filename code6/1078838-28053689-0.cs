    static void Main()
    {
        AppDomain.CurrentDomain.UnhandledException += Unhandled;
        frmLogin loginForm;
        using (loginForm = new frmLogin())
        {
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                NRBQConsts.userName = loginForm.UserName;
                NRBQConsts.pwd = loginForm.Password;
                NRBQConsts.currentSiteNum = loginForm.SiteNumber;
                Application.Run(new frmMain());
            }
        }
    }
