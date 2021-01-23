    private void gridView_DoubleClick(object sender, EventArgs e)
    {
            if (gridView.GetFocusedRow() == null) return;
            if (gridView.GetFocusedRowCellValue("ID") == null) return;
            string id = gridView.GetFocusedRowCellValue("ID").ToString();
            
            FIRSTEditForm frm = new FIRSTEditForm(id);
            frm.Show();
    }
