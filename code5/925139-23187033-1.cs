    SqlGeography geog1 = SqlGeography.STPolyFromText('<coords>', srid);
    SqlGeography geog2;
    DbGeography dbGeog;
    
    // SqlGeography to DbGeography
    dbGeog = DbGeography.FromText(geog1.ToString(), srid);
    // DbGeography to SqlGeography
    geog2 = SqlGeography.Parse(dbGeog.AsText());
