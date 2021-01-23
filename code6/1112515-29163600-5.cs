    var sql = "EXEC dbo.GetTrackListViews @users, @juke";
    var prms = new List<System.Data.SqlClient.SqlParameter>();
    
    //build table valued parameter
    var tbl = new DataTable();
    tbl.Columns.Add(new DataColumn("id", typeof(guid));
    foreach(var user in users) //assume these are guids.
    { tbl.Rows.Add(user) }
    var prm1 = new System.Data.SqlClient.SqlParameter("users", SqlDbType.Structured);
    prm1.Value = tbl;
    prm1.TypeName = "GuidList";
    
    prms.Add(prm1);
    
    // other parameter is easy:
    var prm2 = new System.Data.SqlCliemnt.SqlParameter("juke", juke.ToString());
    prms.Add(prm2);
    List<UserTrackList> results;
    using (var ctx = new spottyData())
    {
        var query = ctx.Database.SqlQuery<UserTrackList>(sql, prms.ToArray());
        results = query.ToList();
        // NB - this works if the property names/types in the type "tracklist" 
        // match the column names/types in the returned resultset.
    }
    // example processing the results
    foreach (var tracklist in results.GroupBy(x => x.UserId)
    {
       user = users.First(x => x == tracklist.Key);
       //do something with the grouped result
    }
