    private void btnAdd_Click(object sender, EventArgs e)
    {
        decimal iQuantity;
        decimal iPrice;
        decimal Fullprice = 0;
        string Product = cmbItem.Text;
        string Quantity = txtQuantity.Text;
        string Price = txtPrice.Text;
        decimal.TryParse(Quantity, out iQuantity);
        decimal.TryParse(Price, out iPrice);
        if (iQuantity <= 0)
        {
            MessageBox.Show("Please enter Quantity larger than 0", "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else if (iPrice <= 0)
        {
            MessageBox.Show("Please enter a valid price above 0", "Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            Fullprice = iPrice * iQuantity;
                                                                                        £{2}                           £{3}",Product,iQuantity,iPrice,Fullprice + Environment.NewLine));
        }
    rtbBasket.AppendText(Product + " " + Quantity + " " Price);
    }
