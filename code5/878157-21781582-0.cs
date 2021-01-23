    DevExpress.XtraEditors.Repository.RepositoryItemDateEdit oItem = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
       
    oItem.DisplayFormat.FormatString = "dd-MM-yyyy HH:mm"
    oItem.EditFormat.FormatString = "dd-MM-yyyy HH:mm"
    oItem.VistaEditTime = DevExpress.Utils.DefaultBoolean.True
    this.colsendTime.ColumnEdit = oItem
    this.colsendTime.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
    this.colsendTime.AppearanceCell.Options.UseBackColor = true;
    this.colsendTime.Caption = "Verzonden op";
    this.colsendTime.Name = "colsendTime";
    this.colsendTime.OptionsColumn.ReadOnly = true;
    this.colsendTime.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
    this.colsendTime.Visible = true;
    this.colsendTime.VisibleIndex = 2;
