    string strColor = GetColor();
    string strMake GetMake();
    decimal decPrice GetPrice();
    if(decPrice != 0)
      .....
    private string GetColor()
    {
        return lstColor.SelectedItem.ToString();
    }
    private string GetMake()
    {
        return lstMake.SelectedItem.ToString();
    }
    private decimal GetPrice()
    {
       decimal price;
       if(!decimal.TryParse(txtMaxPrice.Text, out price))
       {
            MessageBox.Show("Enter a valid number");
       }
       return price;
    }
