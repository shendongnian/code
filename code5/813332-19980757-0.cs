    List<Tbl1Type> GetTbl1Values(Expression<Func<Tbl1Type, bool>> whereClause)
    {
        using (SampleDbEntities dbo = new SampleDbEntities())
        {
            return dbo.Tbl1
                .Where(x => x.Id == (int)comboBoxPerson.SelectedValue)
                .Where(whereClause)
                .Take(1000).ToList();
        }
    }
