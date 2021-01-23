    private void grvUebersicht_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
        DataRow row = (DataRow)grvUebersicht.GetRow(e.FocusedRowHandle);
        DataRow row2 = (DataRow) grvUebersicht.GetRow(e.PrevFocusedRowHandle);
        TextEdit textedit = new TextEdit();
        textedit.Text = row["MyColumn"].ToString();
    }
