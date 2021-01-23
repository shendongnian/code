    var notes = Service.RetrieveMultiple(notesQuery).Entities;
	foreach (var newNote in notes)
	{
		newNote.annotationid = null;
		newNote.Attributes.Add("objectid", new EntityReference("quote", sourceEntity.Id));
		newNote.Attributes.Add("objecttypecode", "quote");
		Service.Create(newNote);
	}
