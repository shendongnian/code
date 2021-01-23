      public static void ShowLoader(string loaderMessage, bool showProgress)
        {
            StatusBarProgressIndicator progressbar = StatusBar.GetForCurrentView().ProgressIndicator;
            progressbar.Text = string.IsNullOrEmpty(loaderMessage) ? "Please wait..." : loaderMessage;
            if (showProgress)
            {
                progressbar.ShowAsync();
            }
            else
            {
                progressbar.HideAsync();
            }
        }
