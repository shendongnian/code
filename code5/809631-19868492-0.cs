    private void btnSubmit_Click(object sender, EventArgs e)
    {
        string strColor = lstColor.SelectedItem.ToString();
        string strMake = lstMake.SelectedItem.ToString();
        decimal decPrice = GetPrice(();
        DisplayResult(strColor, strMake, decPrice);
    }
        
    private decimal GetPrice()
    {
        decimal price;
        if (!decimal.TryParse(txtMaxPrice.Text, out price))
        {
            MessageBox.Show("Enter a valid number");
        }
        return price;
    }
    private void DisplayResult(string color, string make, decimal price)
    {
        lblMessage.Text = string.Format("Color of {0} Make of: {1} {2}",
                                        color, make, price.ToString("c"));
    }
