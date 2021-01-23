    var packagedAjax = showtimesByMovieAndLocation
                .Select(x =>
                        new
                        {
                            playdate = x.PlayDate,
                            experiencetype = x.FFCode,
                            vistasessionid = x.SessionID,
                            areacode = x.AreaCode
                        })
                .GroupBy(x => x.experiencetype)
                .ToDictionary(g => g.Key, g => g.ToList());
