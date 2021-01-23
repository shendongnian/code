    private object bindingSourceTbl1_DataSourceBinding(object sender, EventArgs e)
    {
        using (SampleDbEntities dbo = new SampleDbEntities())
        {
           return dbo.Tbl1.Join(dbo.Tbl2, x => x.Id, y => y.Tbl1Id, (x, y) => new { Tbl1 = x, Tbl2 = y }).Where(a => a.Tbl2.Tbl6Id == (int)comboBoxTbl6.SelectedValue).Select(a => a.Tbl1).Where(Expr1()).ToList();
        }
    }
