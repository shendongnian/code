    if (Properties.Settings.Default.UserStates == null || Properties.Settings.Default.UserStates.Count == 0)
    {
        // Add your users to the collection initially. This is the first
        // run of the application
        userStates.Add(new UserState() { ... });
        ...
    }
    else
    {
        // Each line in the setting represents one user in the form name=state.
        // We split each line into the parts and add them to the internal list.
        for (int i = 0; i < Properties.Settings.Default.UserStates.Count; i++)
        {
            string stateLine = Properties.Settings.Default.UserStates[i];
            string[] parts = stateLine.Split('=');
            userStates.Add(new UserState() { UserName = parts[0].Trim(), CheckedIn = Boolean.Parse(parts[1].Trim()) });
        }
    }
