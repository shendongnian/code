    protected void DemoGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtkms = e.Row.FindControl("txtkms") as TextBox;
            var txtrateperkm = e.Row.FindControl("txtrateperkm") as TextBox;
            var billamt = e.Row.FindControl("billamt") as TextBox;
            var jsFunction = String.Format("CalculateBillAmount('{0}','{1}','{2}');", txtkms.ClientID, txtrateperkm.ClientID, billamt.ClientID);
            txtkms.Attributes.Add("onkeyup", jsFunction);
            txtkms.Attributes.Add("onblur", jsFunction);
            txtrateperkm.Attributes.Add("onkeyup", jsFunction);
            txtrateperkm.Attributes.Add("onblur", jsFunction);
        }
    }
