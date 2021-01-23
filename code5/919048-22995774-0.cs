    (db.Sections.GroupJoin(db.Files, s => s.LogoFileID, f => f.ID, (s, s_f) => new { s, s_f })
			  .Where(@t => s.RouteName == SectionRoute)
			  .SelectMany(@t => s_f.DefaultIfEmpty(), (@t, x) => new GameSectionVM
			                                                     {
				                                                     SectionID = s.ID,
				                                                     GameTitle = s.Title,
				                                                     LogoFileName = x.FileName,
				                                                     Synopsis = s.Synopsi
			                                                     })).Single();
