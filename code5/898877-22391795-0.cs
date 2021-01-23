	var query =
		from subscriber in oDatabase.SMS_Subscribers
		where subscriber.GlobalOptOut == false
		where !(from x in oDatabase.SMS_OutgoingMessages
			where x.Message == sNotificationMessage
			where x.MobileNumber == subscriber.MobileNumber
			where x.Sent > new DateTime(2014, 3, 12)
			select x
		).Any()
		join sk in oDatabase.SMS_SubscribersKeywords
			on subscriber.ID equals sk.SubscriberID
		join k in oDatabase.SMS_Keywords on sk.KeywordID equals k.ID into ks
		from k2 in ks.Take(1)
		let message = new MessageToSend()
		{
			ID = subscriber.ID,
			MobileNumber = subscriber.MobileNumber,
			DemographicID = k2.DemographicID,
			Keyword = k2.Keyword
		}
		select Task.Factory.StartNew(() => SendNotificationMessage(message));
		
	Task.WaitAll(query.ToArray());
