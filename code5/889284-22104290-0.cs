    class GridModel 
    {
        public ColumnModel[] Columns { get; set; }
        public GridRow[] Rows { get; set; }
    }
    class ColumnModel
    {
        public string ColumnName { get; set; }
        public string ColumnLabel { get; set; }
        // other relevant column metadata for sorting, formatting, etc
    }
    class GridRow
    {
        public string[] HiddenFields { get; set; }
        public string[] VisibleFields { get; set; }
    }
