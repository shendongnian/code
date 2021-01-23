    public void LoadData()
    {
        WISSModel.WISSEntities context = new WISSModel.WISSEntities();
        var towers = (from t in context.Towers
                      where t.isDeleted == false
                      select new
                      {
                          t.TowerId,
                          t.TowerName,
                          rangeName = t.Range.RangeName
                      }).ToList();
        DataTable gridviewTable = new DataTable();
        gridviewTable.Columns.Add("TowerId");
        gridviewTable.Columns.Add("TowerName");
        gridviewTable.Columns.Add("rangeName");
        foreach (var t in towers)
        {
            gridviewTable.Rows.Add(new object[] { t.TowerId, t.TowerName, t.rangeName });
        }
        if (!String.IsNullOrEmpty(SortExpression))
        {
            gridviewTable.DefaultView.Sort = String.Format("{0} {1}", SortExpression, SortOrder);
            gridviewTable = gridviewTable.DefaultView.ToTable();
        }
        GridViewTower.DataSource = gridviewTable;
        GridViewTower.DataBind();
    }
 
