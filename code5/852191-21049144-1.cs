    [HttpGet]
    public bool GetUserMessageHistory(string userId, int messageId)
    {
        var userMessageHistory = (from i in db.UserMessageHistories
                                  where i.UserId == userId &&
                                  i.MessageId == messageId
                                  select new
                                  {
                                      UserId = i.UserId,
                                      MessageId = i.MessageId,
                                      LastSeen = i.LastSeen,
                                  }).ToList();
    
    
        return userMessageHistory.any();
    }
