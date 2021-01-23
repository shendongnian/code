    People= xDocument.Root.Descendants("People")
        .Select(se => new { ID=Get<int>(se.Element("ID")) })
        .Where(x => x.ID != i1)
        .Select(x => new Person
              {
                 ID = x.ID,
                 Skills = GetPersonSkills(x.ID)
              }
        ).OrderBy(w => w.FirstName)
        .ToList();
