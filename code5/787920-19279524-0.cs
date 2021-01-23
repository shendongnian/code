    DevExpress.XtraGrid.Columns.GridColumn colMessage= newDevExpress.XtraGrid.Columns.GridColumn();
    
    colMessage.Caption = "Message";
    colMessage.FieldName = "<bound datafield>";
    colMessage.Name = "colMessage";
    colMessage.OptionsColumn.AllowEdit = false;
    colMessage.OptionsColumn.FixedWidth = true;
    colMessage.OptionsColumn.ReadOnly = true;
    colMessage.Visible = true;
    colMessage.VisibleIndex = 0;
    colMessage.Width = 80;
    View.Columns.AddRange(newDevExpress.XtraGrid.Columns.GridColumn[] {
                this.colMessage});
