    protected void TabContainer_OnActiveTabChanged(object sender, EventArgs e)
    {
        if (TabPanelSPU.Visible)
        {
            //Get the list of standard packing unit by distribution
            List<DistributionStandardPackingUnits> SPUList = new List<DistributionStandardPackingUnits>();
            SPUList = packBLL.getAllDistSPUByDistID(distributionID);
            gvSPU1.DataSource = SPUList;
            gvSPU1.DataBind();
        }
        if (TabPanelViewSPUItem.Visible)
        {
            //Get the list of standard packing unit by distribution
            List<DistributionStandardPackingUnits> SPUList = new List<DistributionStandardPackingUnits>();
            SPUList = packBLL.getAllDistSPUByDistID(distributionID);
            gvSPU.DataSource = SPUList;
            gvSPU.DataBind();
        }
    }
