    var ColEntries = _db.Teams.GroupJoin(_db.Entries,     
                                          t => t.Team_ID,   
                                          e => e.Team_ID,      
                                          (t, e) =>       
                                          new { 
                                                  Team = t,
				          Entries = e.Select(en => en).ToList()
                                               }).ToList(); 
