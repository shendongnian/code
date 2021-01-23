    var tasks = new List<Task>();
    foreach (var subscriber in oDatabase.SMS_Subscribers.Where(x => x.GlobalOptOut == false))
    {
       tasks.Add(Task.Factory.StartNew(() => SendNotificationTask(subscriber));
       Thread.Sleep(15);
    }
    //Might want to to use Task.WhenAll instead of WaitAll.  Just need to debug it and see what happens.
    Task.WaitAll(tasks.ToArray());
    public void SendNotificationTask(SomeType subscriber)
    {
        MessageToSend oMessage = new MessageToSend();
        oMessage.ID = subscriber.ID;
        oMessage.MobileNumber = subscriber.MobileNumber;
        int keywordID = 0;
        SMSShortcodeMover.SMS_Keywords keyword;
        
        ////Database call 1
        var recentlySentMessage = oDatabase.SMS_OutgoingMessages.Where(x => x.Message == sNotificationMessage && x.MobileNumber == oMessage.MobileNumber && x.Sent > new DateTime(2014, 3, 12)).FirstOrDefault();
        if (recentlySentMessage != null)
        {
            oMessage.Completed = true;
        }
        else
        {
          try
          {
            ////Database call 2
            keywordID = (int)oDatabase.SMS_SubscribersKeywords.Where(x => x.SubscriberID == oMessage.ID).First().KeywordID;
            
            ////Database call 3
            keyword = oDatabase.SMS_Keywords.Where(x => x.ID == keywordID).First();
        } catch (Exception oEx){ //write exception to console, then continue; }
        oMessage.DemographicID = keyword.DemographicID;
        oMessage.Keyword = keyword.Keyword;
        SendNotificationMessage(oMessage);
       }
   }
