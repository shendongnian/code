    private void OnPlayersChecked(object source, RoutedEventArgs e)
    {
        // must use the same observable instance as the binding uses
        // clear any existing entries
        results.Clear();
        // only care about players...
        foreach (var player in _allPlayersAndManagers.Where(c => c.Job == c.Job.Player))
        {
            results.Add(player);
        }
    }
