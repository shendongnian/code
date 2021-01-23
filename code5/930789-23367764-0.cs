    otherDeduct = ParseValue(txtOtherDeduct.Text);
    taxDeduct = ParseValue(txtTaxDeduct.Text);
    adp.InsertCommand.Parameters.Add("@otherDeduct", SqlDbType.VarChar).Value = otherDeduct;
    adp.InsertCommand.Parameters.Add("@taxDeduct", SqlDbType.VarChar).Value = taxDeduct;
    public double ParseValue(string value)
    {
        return string.isNullOrEmpty(value) ? 0.0M : Convert.ToDecimal(value);
    }
