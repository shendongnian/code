	var data = new List<string>();
	
	var events = doc.Root.Elements("Event");
	
	if (events.Any())
	{
		foreach (var evt in events)
		{
			data.Add(evt.Attribute("DateTime").Value);
		}
	}
	
	var participants = doc.Root.Elements("Participant");
	
	if (participants.Any())
	{
		foreach (var participant in participants)
		{
			data.Add(participant.Attribute("ParticipantID").Value);
		}
	}
	
	var csv = string.Join(", ", data);
