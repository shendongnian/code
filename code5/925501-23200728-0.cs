    private void Quantity_TextChanged(object sender, EventArgs e)
    {
        if(String.IsNullOrWhiteSpace(Quantity.Text))
            return;
        presenter.Quantity = int.Parse(Quantity.Text);
    }
