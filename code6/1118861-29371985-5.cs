    Properties.Settings.Default.UserStates = new System.Collections.Specialized.StringCollection();
    foreach (UserState state in userStates)
    {
        Properties.Settings.Default.UserStates.Add(state.ToString());
    }
    Properties.Settings.Default.Save();
