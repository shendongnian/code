    public shadow string Text
    {
        get{
            return base.Text.Replace("$", "").Replace(",","");
        }
        set{
            base.Text = Convert.ToDecimal(value).ToString("C");
        }
    }
