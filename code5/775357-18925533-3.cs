    [HttpPost]
    public void UpdateTitle(Title title)
    {
        string query; 
        if (title.Operation == 'U')
        {
            query = 
                "UPDATE dbo.AWD_Titles" + 
                " SET AwardStatusId = @AwardStatusID , Description = @Description , IsVerified= @IsVerified , EpisodeAKA= @EpisodeAKA" + 
                " WHERE AwardTitleId= @AwardTitleId ;" + 
                " SELECT SCOPE_IDENTITY();";
        } else {
           //presumably you have a slightly different query string for inserts.
           //Thankfully, they should have pretty much the same set of parameters.
           //If this method will really only be called for updates, the code is quite a bit simpler
        }
        //instead of a shared myConnection object, use a shared connection string.
        // .Net is set up so that you should be creating a new connection object for most queries.
        // I know it sounds backwards, but that's really the right way to do it.
        // Create the connection in a using(){} block, so that you guarantee it is
        //    disposed correctly, even if an exception is thrown.
        using (var cn = new SqlConnection(myConnectionString))
        using (var cmd = new SqlCommand(query, cn))
        {
            //guessing at database types, lengths here. Fix with actual column types
            cmd.Parameters.Add("@AwardStatusId", SqlDbType.Int).Value = title.AwardStatus;
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value = title.Description;
            cmd.Parameters.Add("@IsVerified", SqlDbType.Bit).Value = title.IsVerified;
            cmd.Parameters.Add("@EpisodeAKA", SqlDbType.NVarChar, 100).Value = title.EpisodeAKA;
            cmd.Parameters.Add("@AwardTitleId", SqlDbType.Int).Value = title.AwardTitleId;
            //-------------
            //This is the part that actually answers your question
            foreach (var p in cmd.Parameters.Where(p => p.Value == null))
            {
                p.Value = DBNull.Value;
            }
            //-------------
       
            cn.Open();
            cmd.ExecuteScalar();
        }
    }
