    Properties.Settings.Default.UserStates.Clear();
    foreach (UserState state in userStates)
    {
        Properties.Settings.Default.UserStates.Add(state.ToString());
    }
    Properties.Settings.Default.Save();
