    public static List<Int32> getValueFilterItems()
    {            
        HashSet<Int32> values = new HashSet<Int32>();
        ASPxGridView gridViewPromo = (ASPxGridView)gridViewPromo.GetRowValues(4, "Value");
        int val = Convert.ToInt32(gridViewPromo);
        values.Add(val);
        return values.ToList();
    }
