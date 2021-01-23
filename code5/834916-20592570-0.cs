    var pathsQuery =
        Client.Cypher
            .Match("p = shortestPath((ab:Point)-[*..150]-(cd:Point))")
            .Where((PointEntity ab) => ab.Latitude == 24.96325)
            .AndWhere((PointEntity ab) => ab.Longitude == 67.11343)
            .AndWhere((PointEntity cd) => cd.Latitude == 24.95873)
            .AndWhere((PointEntity cd) => cd.Longitude == 67.10335)
            .Return(p => new PathsResult<PointEntity>
                            {
                                Nodes = Return.As<IEnumerable<Node<PointEntity>>>("nodes(p)"),
                                Relationships = Return.As<IEnumerable<RelationshipInstance<object>>>("rels(p)")
                            });
    var res = pathsQuery.Results;
