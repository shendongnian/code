    var g = context.APP_PROD_COMP_tbl
        .Where(p => p.FAM_MFG == fam_mfg)
        .Select(ToCommonType)   
        .GroupBy(p => new
        {
            a_B_G = p.B_G,
            a_MFG = p.MFG,
            a_PRODUCT_FAM = p.PRODUCT_FAM,
        });
    var q = context.APP_COMP_tbl
        .Where(p => p.FAM_MFG == fam_mfg)
        .Select(ToCommonType)
        .GroupBy(p => new
        {
            a_B_G = p.a_B_G,
            a_MFG = p.a_MFG,
            a_PRODUCT_FAM = p.a_PRODUCT_FAM,
        });
    var data = g.Union(q);
    private CommonClass ToCommonType(APP_PROD_COMP_tbl item)
    {
        return new CommonClass
        {
        };
    }
    private CommonClass ToCommonType(APP_COMP_tbl item)
    {
        return new CommonClass
        {
        };
    }
