    var q = database.Query<MusicItems>(
						"select MI.Name, MI.ResId, MI.Tension from MusicItems MI" 
						+ " inner join MusicInThemes MT"
						+ " on MI.ResId = MT.ResId where MT.ThemeId = ?",
						ThemeID).ToList();
					return q.ConvertAll(x => new Playlist { Name = x.Name, ResId = x.ResId, Tension = x.Tension });
