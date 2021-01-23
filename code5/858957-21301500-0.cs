    public void RunAgainFailedTasks(IEnumerable<Task<Terminal>> tasks)
        {
            Task.Factory.ContinueWhenAll(tasks.ToArray(), antecedents =>
            {
                var failedTasks = new List<Task<Terminal>>();
                foreach (var antecedent in antecedents)
                {
                    var terminal = antecedent.Result;
                    // Previous request was failed
                    if (terminal.Coordinates.AreUnknown)
                    {
                        string address;
                        try
                        {
                            address = terminal.GetNextAddress();
                        }
                        catch (FormatException) // No versions more
                        {
                            continue;
                        }
                        var getCoordinatesTask = CreateGetCoordinatesTask(terminal, address);
                        failedTasks.Add(getCoordinatesTask);
                    }
                    else
                    {
                        _terminalsWithCoordinates.Add(terminal);
                    }
                }
                if (failedTasks.Any())
                {
                    RunAgainFailedTasks(failedTasks);
                }
                else
                {
                    // Display a map
                }
        }
    private Task<Terminal> CreateGetCoordinatesTask(Terminal terminal, string address)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(GeoCoder.GeoCodeUrl + address);
            webRequest.KeepAlive = false;
            webRequest.ProtocolVersion = HttpVersion.Version10; 
            var webRequestTask = Task.Factory.FromAsync<WebResponse>(webRequest.BeginGetResponse,
                                                                    webRequest.EndGetResponse,
                                                                    terminal);
            var parsingTask = webRequestTask.ContinueWith(webReqTask =>
            {
                // Parse the response
            });
            return parsingTask;
        }
