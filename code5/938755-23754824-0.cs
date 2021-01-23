    settings.Columns.Add(clmn =>
    {
         clmn.FieldName = "InsertDate";
         clmn.Caption = TsmDxWeb.Resources.InsertDate;
         clmn.CellStyle.Wrap = DefaultBoolean.False;
         clmn.Width = 150;
         clmn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
         clmn.Settings.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Date;
    });
