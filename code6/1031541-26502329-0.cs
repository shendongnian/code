    RepositoryItemCheckEdit checkEdit = gridOutput.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
    checkEdit.PictureChecked = global::Gyrasoft.Common.DX.Properties.Resources.exclamation;
    checkEdit.PictureUnchecked = global::Gyrasoft.Common.DX.Properties.Resources.accept;
    checkEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
    gridViewOutput.Columns["IsError"].ColumnEdit = checkEdit;
