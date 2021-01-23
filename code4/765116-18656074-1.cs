    People = xDocument.Root.Descendats("People")
        .Select(se => Get<int>(se.Element("ID")))
        .Where(id => id != i1)
        .Select(id => new Person
            {
                ID = id,
                Skills = GetPersonSkills(id)
            })
        .OrderBy(w => w.FirstName)
        .ToList()
