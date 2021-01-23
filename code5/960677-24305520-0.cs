    // two minutes
    var twoMinutes = 2d;
    
    // the query
    var query = Repository.QueryOver<DomainModel.Models.Appointment>();
    
    // the projection using DATEDIFF
    var projection = Projections
        .SqlProjection("DATEDIFF(mi, {alias}.InTime ,{alias}.outTime) as difference"
                   , new[] {"difference"}
                   , new[] {NHibernateUtil.Double});
