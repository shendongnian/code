    IEnumerable<ObjectiveDetail> newOds = ...;
    IEnumerable<ObjectiveDetail> oldOds = ...;
    // build collection of exclusions
    // start with ObjectiveDetail entities that have the same properties
    var propertiesMatched = oldOds.Join( newOds,
        o => new { o.ObjectiveDetailId, o.Number, o.Text },
        n => new { n.ObjectiveDetailId, n.Number, n.Text },
        ( o, n ) => new { Old = o, New = n } );
    // take entities that matched properties and test for same collection
    //  of SubTopic entities
    var subTopicsMatched = propertiesMatched.Where( g =>
        // first check SubTopic count
        g.Old.SubTopics.Count == g.New.SubTopics.Count &&
        // match
        g.New.SubTopics.Intersect( g.Old.SubTopics )
            .Count() == g.Old.SubTopics.Count )
        // select new ObjectiveDetail entities
        .Select( g => g.New );
    // updated ObjectiveDetail entities are those not found
    // in subTopicsMatched
    var upd = newOds.Except( subTopicsMatched );
