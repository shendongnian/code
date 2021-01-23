    [HttpPost]
    public void UpdateTitle(Title title)
    {
        string query = 
            "UPDATE dbo.AWD_Titles" + 
            " SET AwardStatusId = @AwardStatusID , Description = @Description , IsVerified= @IsVerified , EpisodeAKA= @EpisodeAKA" + 
            " WHERE AwardTitleId= @AwardTitleId ;" + 
            " SELECT SCOPE_IDENTITY();";
       var cmd = new SqlCommand(query, myConnection);
       //guessing at database types, lengths here. Fix with actual column types
       cmd.Parameters.Add("@AwardStatusId", SqlDbType.Int).Value = title.AwardStatus;
       cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value = title.Description;
       cmd.Parameters.Add("@IsVerified", SqlDbType.Bit).Value = title.IsVerified;
       cmd.Parameters.Add("@EpisodeAKA", SqlDbType.NVarChar, 100).Value = title.EpisodeAKA;
       cmd.Parameters.Add("@AwardTitleId", SqlDbType.Int).Value = title.AwardTitleId;
       //-------------
       //This is the part that actually answers you question
       foreach (var p in cmd.Parameters.Where(p => p.Value == null))
       {
          p.Value = DBNull.Value;
       }
       //-------------
       
       if (title.Operation == 'U')
       {
            myConnection.Open();
            cmd.ExecuteScalar();
       }
       //the myConnection variable should be in a created in a using{} block!
       myConnection.Close();
    }
