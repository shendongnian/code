    var query = efSchema.TRANS_VALUES.Include("TRANS_CATEGORY");
    if(!string.IsNullOrEmpty(mFormId))
    {
        query = query.Where(defaultValue => defaultValue.FormId.Contains(mFormId));
    }
    if(!string.IsNullOrEmpty(mControlId))
    {
        query = query.Where(defaultValue => defaultValue.ControlId.Contains(mControlId));
    }
    if(mTransCategoryId != -1)
    {
        query = query.Where(defaultValue => defaultValue.TransCategoryId == mTransCategoryId);
    }
    if(!string.IsNullOrEmpty(mDefaultTransValue))
    {
        query = query.Where(defaultValue => defaultValue.DefaultTransValue.Contains(mDefaultTransValue));
    }
    
    gvTransValues.DataSource = query.Select(defaultValue => new 
                            { 
                                TranValueId = defaultValue.TranValueId,
                                FormId = defaultValue.FormId,
                                ControlId = defaultValue.ControlId,
                                TransCategoryId = defaultValue.TransCategoryId,
                                CategoryName = defaultValue.TRANS_CATEGORY.CategoryName,
                                DefaultTranValue = defaultValue.DefaultTranValue,
                            });
