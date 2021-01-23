    protected void rptPendingDmsRequests_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DmsRegisterPod dmsRegisterPod = (DmsRegisterPod)e.Item.FindControl("ucDmsRegisterPod");
            dmsRegisterPod.OnUpdated += dmsRegisterPod_OnUpdated;
        }
    }
