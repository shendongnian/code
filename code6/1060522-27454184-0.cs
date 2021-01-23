    //method called to pass the object pmaActivity as parameter to the MenuPage
    private void btnSave_Click(object sender, EventArgs e)
    {
        Dispatcher.BeginInvoke(() =>
        {
            List<PmaActivity> activities;
            if (PhoneApplicationService.Current.State.ContainsKey("pmaActivities"))
                activities = PhoneApplicationService.Current.State["pmaActivities"];
            else
                activities = new List<PmaActivity>();
            activities.Add(pmaActivity);
            PhoneApplicationService.Current.State["pmaActivities"] = pmaActivities;
            NavigationService.Navigate(new Uri("/MenuPage.xaml", UriKind.Relative));
        });
    }
