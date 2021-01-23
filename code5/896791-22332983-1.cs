    var userLanguage = Language.Language1;
    var results = db.MyEntities.Join(
                      db.StatusTranslations, 
                      e => e.Status, 
                      s => s.Status, 
                      (e, s) => new { MyEntity = e, Status = s }
                )
                .Where(e => e.Status.Language == userLanguage)
                .Select(e => new {
                     MyEntityID = e.MyEntity.MyEntityID
                     StatusName = e.Status.Name
                }).OrderBy(e => e.StatusName).ToList();
