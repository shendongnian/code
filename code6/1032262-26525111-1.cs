    protected void rptPendingDmsRequests_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DealershipIRLink irLink = (DealershipIRLink)e.Item.DataItem;
            DmsRegisterPod dmsRegisterPod = (DmsRegisterPod)e.Item.FindControl("ucDmsRegisterPod");
            dmsRegisterPod.ValidationGroup = string.Format("dms-pod-{0}", e.Item.ItemIndex);
            dmsRegisterPod.DealershipIRLink = irLink;
        }
    }
