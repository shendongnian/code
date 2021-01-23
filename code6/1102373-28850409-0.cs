    if (!Request["id"].IsEmpty())
    {
        using (var repo = new initDatabase("SQLServerConnectionString"))
        {
            var data =  repo.getAllQuery("SELECT * FROM Module WHERE userID = @0", Request["id"])
            Json.Write(data, Response.Output);
        }
    }
