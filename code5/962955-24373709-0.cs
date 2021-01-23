     public void getQuanPrice() // call getQuantityPrice form
     {
        QuantityPriceForm obj = new QuantityPriceForm(this);
        obj.quant = (int)dgvProducts.CurrentRow.Cells[2].Value;
        obj.agreePrice = (double)dgvProducts.CurrentRow.Cells[3].Value;
        if (obj.ShowDialog() == DialogResult.OK)
        {
          dgvProducts.CurrentRow.Cells[2].Value = obj.quant;
          dgvProducts.CurrentRow.Cells[3].Value = obj.agreePrice;
        }
     }
