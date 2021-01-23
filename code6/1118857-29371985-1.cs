    if (Properties.Settings.Default.UserStates.Count == 0)
    {
        // Add your users to the collection initially. This is the first
        // run of the application
        Properties.Settings.Default.UserStates.Add(new UserState() { ... });
        ...
    }
    else
    {
        for (int i = 0; i < Properties.Settings.Default.UserStates.Count; i++)
        {
            string stateLine = Properties.Settings.Default.UserStates[i];
            string[] parts = stateLine.Split('=');
            userStates.Add(new UserState() { UserName = parts[0], CheckedIn = Boolean.Parse(parts[1]) });
        }
    }
