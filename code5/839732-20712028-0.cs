    decimal total = 0D;
    for (int i = 0; i < grdCart.Rows.Count; ++i)
    {
        total += Convert.ToDecimal(grdCart.Rows[i].Cells[3].Value);
    }
    Label2.Text = total.ToString();
