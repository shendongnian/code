    private async Task DoWebRequestsAsync()
    {
      List<requestInfo> requestInfoList = new List<requestInfo>();
      for (int i = 0; dataRequestInfo.RowCount - 1 > i; i++)
      {
        requestInfoList.Add((requestInfo)dataRequestInfo.Rows[i].Tag);
      }
      await Task.WhenAll(requestInfoList.Select(async i => 
      {
        await maxThread.WaitAsync();
        try
        {
          await Global.WebRequestWorkAsync(i);
        }
        finally
        {
          maxThread.Release();
        }
      }));
    }
