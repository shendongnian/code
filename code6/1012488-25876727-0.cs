    static bool first = true;
    public override Uri MapUri(Uri uri)
    {
        if (uri.OriginalString == "/LaunchPage.xaml")
        {
            if (first) MessageBox.Show("Searching for LaunchPage...");
            
            if (App.IsFirstRun())
            {
                if (first) MessageBox.Show("First run...Should show introductionPage...");
                uri = new Uri("/MainPage.xaml", UriKind.Relative);
            }
            else
            {
                if (first) MessageBox.Show("...Should show MainPage...");
                uri = new Uri("/IntroductionPage.xaml", UriKind.Relative);
            }
            }
            first = false;
        }
        return uri;
    }
