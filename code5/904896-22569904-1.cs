    var tags = incident.Tags.Split(',').Select(t => t.Trim()).ToList();
    var validSuggestions = db.Knowledgebases.Where(k => tags.Any(t => k.Title.Contains(t))
                                            .Select(k => new KnowledgebaseViewModel()
                                                        {
                                                          ID = k.ID,
                                                          Title = k.Title,
                                                          Link = k.Link
                                                        })
                                            .ToList();
    //here goes if (validSuggestions > 2) ...
            
