    class Table {
        public int SelectedIndex { get; set; }
        public Row[] Rows { get; set; }
    
        public Row SelectedRow {
            get {
                if (Rows == null)
                    throw new InvalidOperationException("...");
    
                // No or wrong selection, here we just return null for
                // this case (it may be the reason we use this property
                // instead of direct access)
                if (SelectedIndex < 0 || SelectedIndex >= Rows.Length)
                    return null;
    
                return Rows[SelectedIndex];
            }
    }
