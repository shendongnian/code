    protected void Substance_Master_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Substance_Master.PageIndex = e.NewPageIndex;
        var sortField = Substance_Master.Attributes["CurrentSortField"];
        var sortDirection = Substance_Master.Attributes["CurrentSortDirection"];
    
        if (sortField != null && sortDirection != null)
        {
            Substance_Master.DataSource = Substance_MasterAccessLayer.GetAllSubstances(sortField + "" + sortDirection);
        }
    
        Substance_Master.DataBind();
    }
