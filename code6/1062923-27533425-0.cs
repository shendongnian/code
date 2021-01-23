    public async Task<bool> ProcessInboxAsync(List<SessionContext> sessionContextList, FsFcsService curSvc)
    {
      bool resultBool = false;
      List<SessionContext> tempSessionList = sessionContextList.ToList();
      return await ProcessDbList(tempSessionList, curSvc);
    }
