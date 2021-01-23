    static void dt_RowChanged(object sender, DataRowChangeEventArgs e)
    {
        e.Row.Table.RowChanged -= dt_RowChanged;
        e.Row["statusNormalized"] = e.Row["status"].ToString().ToLower();
        foreach (var kvPair in NormalizationMapping.EncodingMapping)
        {
            e.Row["statusNormalized"] = kvPair.Value
                .Replace(e.Row["statusNormalized"].ToString(), kvPair.Key);
        }
        e.Row.AcceptChanges();
        e.Row.Table.RowChanged += dt_RowChanged;
    }
