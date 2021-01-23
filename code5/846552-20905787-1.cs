    var bw = new BackgroundWorker();
    bw.DoWork += (s, e) =>
      {
        var nodePropertiesCount = (int)e.Argument;
        // the guts of `Discovery` go in here
        e.Result = NetworkedComputers;
      };
    bw.RunWorkerCompleted += (s, e) =>
      {
        if (e.Error != null)
        {
            // Task Completed Successfully
            ListView_LocalComputers = (List<DiscoveredComputer>)e.Result;
        }
        else
        {
            // Error Encountered
        }
      };
    bw.RunWorkerAsync(Node.Properties.Count);
