    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
      if(e.NavigationMode!=NavigationMode.Back)
        {
            if (NavigationContext.QueryString.ContainsKey("Id"))
            {
                Id.Text = NavigationContext.QueryString["Id"];
    
            }
            ScheduledAction currentReminder = ScheduledActionService.Find(NavigationContext.QueryString["Id"]);
            if (currentReminder == null)
            {
                cBox.IsChecked = false;
            }
            else 
            {
                cBox.IsChecked = true;
                rrDate.Value = currentReminder.BeginTime;
                hiddenTime.Text = rrDate.Value.ToString();
                rrTime.Value = DateTime.Parse(hiddenTime.Text);
            }
          }
        }
