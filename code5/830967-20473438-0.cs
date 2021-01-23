    private void Break_ValueChanged(object sender, EventArgs e)
    {
        DataView dvBreaks = ParentForm.CurrentUser
            .Cache
            .GetERPLuTableFromCache( Db.CustomDbMetaData.CachedTables.Breaks )
            .DefaultView
            .ToTable()
            .DefaultView;
        if( Convert.ToString( Break.Value ) != string.Empty ) {
            dvBreaks.RowFilter = "BREAK = '" + Convert.ToString( Break.Value ) + "'";
        }
    }
