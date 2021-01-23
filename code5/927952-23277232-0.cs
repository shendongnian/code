    var creatorNotes = list
        .GroupBy(note => note.CreatorID)
        .Select(g => new
        {
            g.CreatorID,
            Notes = g.ToList()
        })
        .ToList();
