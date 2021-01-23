    public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
    {
        SPSecurity.RunWithElevatedPrivileges(delegate()
        {
            using (SPSite site = new SPSite((properties.Feature.Parent as SPSite).ID))
            {
                DeleteJob(site);
            }
        });
    }
