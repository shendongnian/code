    public HttpResponseMessage Get_Record(string id)
    {
        // Get DataTable
        DataTable dt = new DataTable();
        dt = db.GetRecord(id);
        
        var records = dt.Rows.Select(r => new Record()
        {
            ID = row.Field("ID"),
            Title = row.Field("Title"),
            Users = row.Field("Users")
        });
        
        return this.Request.CreateResponse(HttpStatusCode.OK,
            new
            {
                Response = new
                {
                    ID = records.First().ID,
                    Title = records.First().Title,
                    Users = records.Select(r => r.Users)
                }
            });
    }
