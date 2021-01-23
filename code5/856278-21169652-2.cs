    for(int i=0; i< gridView1.RowCount; i++)
    {
        var totalprice = Convert.ToDecimal(gridView.GetRowCellValue(i, "TotalPrice"));
        var quantity = Convert.ToDecimal(gridView.GetRowCellValue(i, "Quantity"));
        gridView1.SetRowCellValue(i,"UnitPrice",(totalprice / quantity));
    }
