    Dictionary<int, Client> clients = new Dictionary<int, Client>();
    foreach (AllTableView tableView in AllTableViewCollection)
    {
        if (clients.ContainsKey(tableView.ClientID) == false)
        {
            clients.Add(tableView.GetClient());
        }
    }
