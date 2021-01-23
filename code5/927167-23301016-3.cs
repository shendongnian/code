    private List<MyUserControlData> GetUserControlData()
    {
        var lst = new List<MyUserControlData>();
        foreach(RepeaterItem item in rpt.Items)
        {
            var uc = item.FindControl("myUserCtrl") as MyUserControl;
            if (uc != null)
                lst.Add(uc.Data);
        }
        return lst;
    }
