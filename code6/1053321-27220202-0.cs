    Double prodPrice = 0;
    
    if (Double.TryParse(this.textProdName.Text, out prodPrice))
    {
        ((Employee)o).ProdPrice = prodPrice;
    }
    else
    {
        // do something when textProdName.Text can't be converted to double
    }
