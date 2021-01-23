    protected void Button1_Click(object sender, EventArgs e)
    {
        decimal total = 0;
    
        foreach (ListItem item in MyCheckBoxList.Items)
             if (item.Selected)
             {
                 decimal selectedValue = 0;
    
                 if (decimal.TryParse(item.Value, out selectedValue))
                 {
                     total = total + selectedValue;
                 }
             }
    }
