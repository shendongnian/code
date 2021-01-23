    db.Entry(team).State = EntityState.Modified;
    db.SaveChanges();
    var updatedTeam = db.Teams.Include(x=> x.GameType).Where(x=> x.ID == team.ID).Single();
    updatedTeam.GameType = db.GameTypes.Find(GameTypeId);
    db.SaveChanges();
    
