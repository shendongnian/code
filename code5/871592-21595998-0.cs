    protected void txtmaths_TextChanged(object sender, EventArgs e)
    {
        UpdateTotals();
    }
    
    protected void txtsci_TextChanged(object sender, EventArgs e)
    {
        UpdateTotals();
    }
    
    protected void txtenglish_TextChanged(object sender, EventArgs e)
    {
        UpdateTotals();
    }
    protected void UpdateTotals()    
    {
       int a = Convert.ToInt32(txtmaths.Text);
       int b = Convert.ToInt32(txtsci.Text);
       int c = Convert.ToInt32(txtenglish.Text);
       int tot = a + b + c;
       txttotal.Text = tot.ToString();
    } 
