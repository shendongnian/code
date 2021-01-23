    public Expression<Func<vSEARCH_ClaimsReport, bool>> GetExpression(
        string valuesToProcess)
    {
        Expression<Func<vSEARCH_ClaimsReport, bool?>> selector = 
            item => item.IsMDL;
        return selector.Compose(base.GetFilterFunc(valuesToProcess));
    }
