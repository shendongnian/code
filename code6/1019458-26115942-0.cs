    void TraverseRows(ColumnView view) {
        for (int i = 0; i < view.DataRowCount; i++) {
            object row =  view.GetRow(i);
            // do something with row
        }
    }
