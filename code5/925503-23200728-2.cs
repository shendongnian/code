    private void Quantity_TextChanged(object sender, EventArgs e)
    {
        int quantity;
        if(int.TryParse(Quantity.Text,out quantity))
          presenter.Quantity = quantity.ToString();
    }
