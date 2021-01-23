     var t = Projections.SqlFunction("round", NHibernateUtil.Int32, Projections.GroupProperty("rating"));
     var output = sess.QueryOver<Song>()
           .SelectList(list => list
           .Select(Projections.SqlFunction("round", NHibernateUtil.Int32, Projections.GroupProperty(t)))
           .SelectCount(s => s.song_id))
           .List<object[]>()
           .Select(prop => new RatingStat
            {
                rating = (int)prop[0],
                count = (int)prop[1]
            }).ToList<RatingStat>();
