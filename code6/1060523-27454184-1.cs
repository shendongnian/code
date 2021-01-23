    //Method called to receive the pmaActivity and add in the collection
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (PhoneApplicationService.Current.State.ContainsKey("pmaActivity"))
        {
            if (PhoneApplicationService.Current.State.ContainsKey("pmaActivities"))
            {
                var pmaActivities = PhoneApplicationService.Current.State["pmaActivities"] as List<PmaActivity>;
                foreach (var activity in pmaActivities)
                    ListActivitiesAdvanced.Add(activity);
            }
        }
