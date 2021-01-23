    private async void StartToastCycle(int MaxNotifications)
    {
        while (App.RunningInBackground)
        {
            if (NotificationCount >= MaxNotifications || !App.RunningInBackground)
                break;
            if (NotificationCount < MaxNotifications && NotificationLastSent < DateTime.Now.AddMinutes(-2))
            {
                Microsoft.Phone.Shell.ShellToast toast = new Microsoft.Phone.Shell.ShellToast();
                toast.Content = "Test";
                toast.Title = "Test: ";
                toast.NavigationUri = new Uri("/Views/HomePage.xaml", UriKind.Relative);
                toast.Show();
                NotificationCount++;
                NotificationLastSent = DateTime.Now;
            }
            await Task.Delay(TimeSpan.FromSeconds(10));
             
        }
    }
