    public shadow string AmountText
    {
        get{
            return txtAmount.Text.Replace("$", "").Replace(",","");
        }
        set{
            txtAmount.Text = Convert.ToDecimal(value).ToString("C");
        }
    }
