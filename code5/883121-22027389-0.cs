    List<Tab> tabList = new List<Tab>();
    Recipient[] recipients = newEnvelope.Recipients;
    foreach (Recipient r in recipients)
    {
        Tab tab = new Tab();
        tab.RecipientID = r.ID;
        tab.TabLabel = string.Format("Recipient{0}Name", r.ID);
        tab.Value = r.UserName;
        tab.DocumentID = "1";
        tabList.Add(tab);
    }
    newEnvelope.Tabs = tabList.ToArray();
