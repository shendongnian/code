    private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var row = gridView1.GetFocusedDataRow();
            object obj1 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DiscountPercentage"]) == DBNull.Value
                            ? 0
                            : (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DiscountPercentage"]));
            int inte1 = Convert.ToInt32(obj1);
            object obj2 = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DiscountAmount"]) == DBNull.Value
                            ? 0
                            : (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DiscountAmount"]));
            int inte2 = Convert.ToInt32(obj2);
            // Calculating the dicsount %
            if (e.Column == colDiscountAmount)
            {
                if (inte2 == 0)
                {
                    return;
                }
                else
                {
                    var productPrice = Convert.ToDecimal(row["UnitPrice"]);
                    var quan = Convert.ToDecimal(row["Quantity"]);
                    var discountAmout = Convert.ToDecimal(row["DiscountAmount"]);
                    var temp = (discountAmout * 100) / (productPrice * quan);
                    row["DiscountPercentage"] = temp.ToString("n2");
                }
            }
            // Calculating the discount amount
            if (e.Column == colDiscountPercentage)
            {
                if (inte1 == 0)
                {
                    return;
                }
                else
                {
                    var productPrice = Convert.ToDecimal(row["UnitPrice"]);
                    var quan = Convert.ToDecimal(row["Quantity"]);
                    var discountPercent = Convert.ToDecimal(row["DiscountPercentage"]);
                    var temp1 = (productPrice * quan) * (discountPercent / 100);
                    row["DiscountAmount"] = temp1.ToString("n2");
                }
            }
        }
