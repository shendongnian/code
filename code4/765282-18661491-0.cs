    string fileTitle = "Foo";
    string fileContent = "Bar";
    var action = ScheduledActionService.Find(fileTitle);
    if (action == null)
    {
        // shouldn't be null if it was already added from the app itself.
        // should get the date the user actually wants the alarm to go off.
        DateTime date = DateTime.Now.AddSeconds(30);
        action = new Reminder(fileTitle) { Title = fileTitle, Content = fileContent, BeginTime = date };
    }
    else if (action.IsScheduled == false)
    {
        ScheduledActionService.Remove(fileTitle);
        // most likely fired today, add two days to the begin time.
        // best to also add some logic if BeginTime.Date == Today
        action.BeginTime = action.BeginTime.AddDays(2);
    }
    ScheduledActionService.Add(action);
