    // Create the collection from scratch
    Properties.Settings.Default.UserStates = new System.Collections.Specialized.StringCollection();
    // Add all the users and states from our internal list
    foreach (UserState state in userStates)
    {
        Properties.Settings.Default.UserStates.Add(state.ToString());
    }
  
    // Save the settings for next start
    Properties.Settings.Default.Save();
