    public class Table1Map : ClassMap<Table1>
    {
        public Table1Map()
        {
            // Other mappings here...
            References(a => a.Table2).Nullable()
                                     .Columns("Table2Id")
                                     .ApplyFilter<SpecificCategoryFilter>()
                                     .ApplyFilter<SpecificLanguageFilter>()
                                     .ReadOnly();
        }
    }
