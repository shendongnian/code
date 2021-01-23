    public async Task<string> ReadLinesAsync(CancellationToken token)
    {
        _readBuffer = new byte[c_readBufferSize];
        // start asynchronously reading data
        int readResult = await _networkstream.ReadAsync(_readBuffer, 0, c_readBufferSize, token);
        // after data arrives...
        // resize the result to the size of the data that was returned
        Array.Resize(ref _readBuffer, streamTask.Result);
        // convert returned data to string
        return Encoding.ASCII.GetString(_readBuffer);
    }
    async public override void Start()
    {
        try
        {
            string text = await _client.ReadLinesAsync(_cts.Token);
            await ReadLinesOnContinuationAction(text);
        }
        catch (AggregateException ae)
        {
            ae.Handle((exc) =>
            {
                if (exc is TaskCanceledException)
                {
                    _log.Info(Name + " - Start() - AggregateException"
                        + " - OperationCanceledException Handled.");
                    return true;
                }
                else
                {
                    _log.Error(Name + " - Start() - AggregateException - Unhandled Exception"
                    + exc.Message, ae);
                    return false;
                }
            });
        }
        catch (Exception ex)
        {
            _log.Error(Name + " - Start() - unhandled exception.", ex);
        }
    }
    async private Task ReadLinesOnContinuationAction(Task<String> text)
    {
        try
        {
            DataHasBeenReceived = true;
            IsConnected = true;
            _readLines.Append(text.Result);
            if (OnLineRead != null) OnLineRead(Name, _readLines.ToString());
            _readLines.Clear();
            string text = await _client.ReadLinesAsync(_cts.Token);
            await ReadLinesOnContinuationAction(text);
        }
        catch (Exception)
        {
            _log.Error(Name + " - ReadLinesOnContinuationAction()");
        }
    }
