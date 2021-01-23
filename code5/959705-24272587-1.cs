    delegate void setLabelText(string s);
    public void invokeSetLabelText(string s)
    {
        if (this.lblResults.InvokeRequired)
        {
            setLabelText d = new setLabelText(invokeSetLabelText);
            this.Invoke(d, new object[] { s });
        }
        else
            lblResults.Text = s;
    }
    protected void currency_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (stm_currency.SelectedItem != null)
            invokeSetLabelText(string.Format("{0} statement for {1} {2}", 
                stm_merchant.SelectedItem.Text,
                stm_month.SelectedItem.Text, 
                stm_year.SelectedItem.Text));
        else
            invokeSetLabelText(string.Empty);
    }
