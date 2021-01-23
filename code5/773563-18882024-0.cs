	public bool EditLogEvent(LogEvent logEvent, out LogEvent editedLogEvent,...){
		...
		using (var db = new DistributorEntities()){
			var oldLogEvent = db.LogEvents
				.Include(o => o.Contacts)
				.Include(o => o.LogEventAttachments)
				.Single(o => o.LogEventID == logEvent.LogEventID);
			oldLogEvent.Contacts.Clear();
			foreach (var cont in logEvent.Contacts)
			{
				var contact = db.Contacts.SingleOrDefault(c => c.ContactID == cont.ContactID);
				oldLogEvent.Contacts.Add(contact);
			}
			db.LogEvents.ApplyCurrentValues(logEvent);
			db.SaveChanges();
			var editedLogEvent = db.LogEvents
				.Include(o => o.Contacts)
				.Include(o => o.LogEventAttachments)
				.Single(o => o.LogEventID == logEvent.LogEventID);
				...
		}
	}
