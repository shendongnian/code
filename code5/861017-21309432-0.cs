    public void Delete(Guid[] guids)
    {
       DataTable table = ReadTemplateList()
                             .AsEnumerable()
                             .Where(r => guids.Contains(r.Field<Guid>("ColumnName")))
                             .CopyToDataTable();
       // ...
    }
