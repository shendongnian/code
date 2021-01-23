    var userId = de.User_Details
            .Where(m => m.Name.Contains(Session["user"].ToString()))
            .Select(m => new{ m.User_Id })
            .FirstOrDefault();
    var lis = Enumerable.Empty<TimeSheetUserStatus>();
    if(userId != null)
    {
        lis = de.TimeSheetUserStatus
            .Where(t => t.Leader_User_Id == userId.User_Id);
    }
    grdTimeSheet.DataSource = lis.ToList();
    grdTimeSheet.DataBind();
