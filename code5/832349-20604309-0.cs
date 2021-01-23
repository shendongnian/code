    private void repositoryItemGridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
    {
        GridLookUpEdit LookupEdit = sender as GridLookUpEdit;
        DataRowView SelectedDataRow = (DataRowView)LookupEdit.GetSelectedDataRow();
        gridView1.SetFocusedRowCellValue("Description", SelectedDataRow["ProductDescription"]);
        gridView1.SetFocusedRowCellValue("UoM", SelectedDataRow["UnitofMeasure"]);
        gridView1.SetFocusedRowCellValue("Quantity", SelectedDataRow["DefaultQuantity"]); //UnitPrice
        gridView1.SetFocusedRowCellValue("UnitPrice", SelectedDataRow["MRPPrice"]);
        gridView1.SetFocusedRowCellValue("DiscountPercentage", SelectedDataRow["Discount"]);
        gridView1.SetFocusedRowCellValue("DiscountAmount", SelectedDataRow["DiscountAmount"]);
        gridView1.SetFocusedRowCellValue("TaxInPercentage", SelectedDataRow["Taxid1"]);
        //  Taxamountcalc(); 
        //  rowcount = gridView1.RowCount; 
    }
