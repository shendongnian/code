    public static Int32 getValueFilterItems(int visibleIndex, string fieldNames)
    {            
        ASPxGridView gridViewPromo = (ASPxGridView)gridViewPromo.GetRowValues(visibleIndex,fieldNames);
        return Convert.ToInt32(gridViewPromo);
    }
