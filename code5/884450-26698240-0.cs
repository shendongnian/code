    RootFrame.Navigating += RootFrame_Navigating;
    void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
    {
        if(e.Uri.OriginalString=="app://external/")
        {
            // update the custom tiles here and the resume error is gone..
        }
    }
