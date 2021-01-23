    IQueryable<Contenidos> miConsulta =
           miDBContext.Contenidos.Include(x => x.Videos)
                   .Select(x => new {
                        GenerosVideos = x.Videos.Select(v=>v.GenerosVideos).ToList()
                   });
