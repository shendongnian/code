    void newButton_Click(object sender, EventArgs e)
    {
        Action navigate = () =>
            this.NavigationService.Navigate(new uri("/NewPage.xaml", UriKind.Relate));
        if (Settings.EnableVibration.Value)  //boolean flag to tell whether to vibrate or not
        {
            VibrateController.Default.Start();
            Task.Delay(100).ContinueWith(t =>
            {
                VibrationController.Default.Stop();
                navigate();
            });
        }
        else
            navigate();
    }
