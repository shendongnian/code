    private void CreatRow(
        string networkIdToCreate,
        string business)
    {
        HTExtractSchema.HTProviderMedicalGroupContractRow rHTProviderMedicalGroupContract = 
            tblHTProviderMedicalGroupContract.NewHTProviderMedicalGroupContractRow();
        rHTProviderMedicalGroupContract.ItemArray = 
            rHTProviderMedicalGroupContractDefaults.ItemArray;
        rHTProviderMedicalGroupContract.NetworkId = networkIdToCreate;
        rHTProviderMedicalGroupContract.Business = business;
        tblHTProviderMedicalGroupContract.Rows.Add(rHTProviderMedicalGroupContract);
    }
