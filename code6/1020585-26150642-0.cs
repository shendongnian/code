    var sqlQuery = new StringBuilder();
    
    sqlQuery.Append("SELECT DISTINCT a.city AS City, a.zip AS Zip ");
    sqlQuery.Append("FROM zip_city AS a ");
    sqlQuery.Append("WHERE country = 1 ");
    
    for (int i = 0; i < areas.Count; i++)
    {
        if (i == 0)
        {
            sqlQuery.Append("AND (a.area_id = @p" + i.ToString());
        }
        else
        {
            sqlQuery.Append(" OR a.area_id = @p" + i.ToString());
        }
    }
    sqlQuery.Append(")");
    
    var results = db.Database.SqlQuery<LocationModel>(sqlQuery.ToString(), areas.ToArray()).ToList();
