    var actor = new Actor { Name = "Actor Name" };
    var movie = new Movie { Name = "Movie Name" };
    var association = new MovieActorAssociation(actor, movie);
    actor.MovieAssociations.Add(association);
    movie.ActorAssociations.Add(association);
    // some way of getting a Session
    var session = SessionFactory.GetCurrentSession();
    using (var transaction = session.BeginTransaction())
    {     
        session.Save(actor);
        transaction.Commit();
    }
