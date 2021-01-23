	int? incidentID;				  
	var person = buPerson.Where( 
		p => p.IsDeleted == 0 
		    && (!string.NullOrWhitespace(p.NameFirst) 
	        ||  !string.NullOrWhitespace(p.NameLast)).FirstOrDefault();					  
	if ( person != null )
		incidentID = person.IncidentID;
	else {
		var incident = buInjury.Where( 
			i => i.IsDeleted == 0 
			    && (!string.NullOrWhitespace(i.TimeLossEstimateTerms) 
			    ||  !string.NullOrWhitespace(i.ResultOtherDesc)).FirstOrDefault();	
		if ( incident != null )
			incidentID = incident.IncidentID;
	}
	if ( incidentID.HasValue() )
	{
		var detail = buIncident
                        .FirstOrDefault(j=>j.IncidentID.Value)
                        .Select(j => new { k => new { 
                                ID = k.IncidentID, 
                                When = g.OccurWhen, 
                                Where = g.OccurWhere, 
                                Description = g.Description };
		if ( detail != null )
			Console.WriteLine( "{0}, {1}, {2}, {3}",  
                             detail.IncidentID, 
                             detail.OccurWhen, 
                             detail.OccurWhere, 
                             detail.Description);
	}
	else
		Console.WriteLine("No incident found");
