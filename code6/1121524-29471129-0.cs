    public IList<DistrictSupervisorViewModel> GetAssignedDistricts()
    {
        IList<DistrictSupervisorViewModel> lsp = idistrictsupervisorrepository
                .GetList(x => x.IsActive == true && x.IsDelete == false)
                .Select(x => new DistrictSupervisorViewModel { DistrictId = x.District.DistrictId, DistrictName = x.District.DistrictName }).DistinctBy(p => p.DistrictId).ToList();
        return lsp;
    }  
   
