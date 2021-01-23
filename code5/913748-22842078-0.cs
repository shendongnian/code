    public async Task<ISession> GetSessionInfoAsync(int accountId, int siteId, int visitorId, int sessionId)
    {
      //some type of validation
      var session = await GetValidSession(accountId, siteId, visitorId, sessionId);
      BackgroundTaskManager.Run(() => DataAdapter.UpdateSessionCheckAsync(sessionId, DateTime.UtcNow));
      return new Session
      {
        Id = sessionId,
        VisitorId = session.VisitorId
      };
    }
