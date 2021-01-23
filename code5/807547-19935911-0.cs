    private void detail_ItemDataBound(object sender, EventArgs e)
    {
        Telerik.Reporting.Processing.DetailSection section = (sender as Telerik.Reporting.Processing.DetailSection);
        Telerik.Reporting.Processing.TextBox = (Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.GetChildByName(section, "textBox14");
        Telerik.Reporting.Processing.TextBox = (Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.GetChildByName(section, "textBox15");
        Telerik.Reporting.Processing.TextBox txtTotal = (Telerik.Reporting.Processing.TextBox)Telerik.Reporting.Processing.ElementTreeHelper.GetChildByName(section, "textBox16");
        txtTotal.Value = (Convert.ToInt32(txtAmt.Value) + Convert.ToInt32(txtTax.Value)).ToString();
    }
