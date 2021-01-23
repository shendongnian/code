    public string GetAllCategorySettings()
    {
        csr.CategorySettingsList = new ListCategorySettings<>();
        var cs = new CategorySettings
            {
               NeedsLoginToViewLongText = true,
               ...
