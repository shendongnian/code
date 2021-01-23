    foreach(Recipient r in envelope.Recipients) {
        Tab tab = newTabs.ElementAt(14); // Just a custom text tag
        tab.RecipientID = r.ID;
        tab.Value = r.UserName;
        tab.TabLabel = r.ID; // or some other unique value for each recipient
        newTabs.Add(tab); //The older tab info gets replaced by the new tab info.
                          // all are still there, the old ones just have the same info
                          // as the latest added one
     }
