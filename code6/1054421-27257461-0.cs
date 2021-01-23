    using (SqlDataSource ds = AllUsers)
    {
        Guid guid = new Guid();
        try
        {
            guid = Guid.Parse(Session["user_id"].ToString());
        }
        catch { guid = Guid.NewGuid(); }
    
        ds.UpdateCommand = "UpdateUser";
        ds.ConflictDetection = ConflictOptions.OverwriteChanges;
        ds.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
    
        ds.UpdateParameters.Clear();
    
        ds.UpdateParameters.Add("userid", guid.ToString());
        ds.UpdateParameters.Add("username", "Diogo");
        ds.UpdateParameters.Add("email", "user_test@gmail.com");
        ds.UpdateParameters.Add("isAnonimo", "0");
        ds.UpdateParameters.Add("isLocked", "0");
        ds.UpdateParameters.Add("roleId", "");
    
        ds.Update();
        DetailsView1.DataBind();
    }
