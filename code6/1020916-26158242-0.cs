    protected StoreDetailModel GetSelectedStore()
    {
        if (StoresWithDepartmentType == null || !StoresWithDepartmentType.Any())
        {
            return null;
        }
        StoreDetailModel currentUserStore = WebsiteContext.GetCurrentUserStore();
        if (currentUserStore == null || currentUserStore.Item == null)
        {
            return null;
        }
        return StoresWithDepartmentType.FirstOrDefault(x => x.Item.ID == currentUserStore.Item.ID) ?? StoresWithDepartmentType.First();
    }
