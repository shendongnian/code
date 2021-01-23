    DataGridViewImageColumn ic = new DataGridViewImageColumn();
    ic.HeaderText = "Payment";
    ic.Image = null;
    ic.Name = "cImg";
    ic.Width = 50;
    dtGrCustBal.Columns.Add(ic);
    foreach (DataGridViewRow row in dtGrCustBal.Rows)
     {
      DataGridViewImageCell cell = row.Cells[10] as DataGridViewImageCell;
      cell.Value ="your namespace".Properties.Resources.icon_payment_cash_small;       
     }
