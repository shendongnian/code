    private IEnumerable<PIPoint> Search(string Server, string NameSearch, string PointSourceSearch)
    {
      PIServers KnownServers = new PIServers();
      PIServer server = KnownServers[Server];
      // TODO: If "Connect" or "FindPIPoints" are naturally asynchronous,
      //  then this method should be converted back to an asynchronous method.
      server.Connect();
      return PIPoint.FindPIPoints(server, NameSearch, PointSourceSearch);
    }
    public ICommand SearchCommand
    {
      get
      {
        if (_SearchCommand == null)
        {
          _SearchCommand = AsyncCommand.Create(async () =>
          {
            var results = await Task.Run(
                Search(_CurrentPIServer, NameSearch, PointSourceSearch));
            SearchResults = new ObservableCollection<string>(
                results.Select(x => x.Name));
          });
        }
        return _SearchCommand;
      }
    }
