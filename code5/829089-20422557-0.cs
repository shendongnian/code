    var query = from type in db.TempR_ThermometerType
                select type;
    
    if (groupId >= 0)
    {
        query = query.Where(type => type.GroupID == groupId);
    }
    if (siteId >= 0)
    {
        query = query.Where(type => type.SiteID == siteId);
    }
    ...
    return query.ToList();
