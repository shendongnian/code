    protected void ButtonCalculate_Click(sender object, EventArgs e)
    {
        decimal total = calculatePrice(DropDownList1.SelectedItem.Text,  
                                       TextBoxQuantity.Text.Trim());
        LabelResult.Text = "You would like " + TextBoxQuantity.Text.Trim() + 
            DropDownList1.SelectedItem.Text + "(s) for a total of $" + 
            total.ToString(); 
    }
    private decimal calculatePrice(string fruitName, int quantity)
    {
        // Ask the database for the price of this particular piece of fruit by name
        decimal costEach = GoToDatabaseAndGetPriceOfFruitByName(fruitName);
        return costEach * quantity;
    }
