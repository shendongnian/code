    // aDateColumn is the column you want to format
    // Custom mask
    RepositoryItemTextEdit columnEdit = new RepositoryItemTextEdit();
    columnEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
    columnEdit.Mask.EditMask = "d";
    aDateColumn.ColumnEdit = columnEdit;
