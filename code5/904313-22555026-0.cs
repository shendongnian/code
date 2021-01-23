        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTotal = (Label)e.Row.FindControl("lbltotal");
            if (lblTotal != null)
            {
                total = Decimal.TryParse(DataBinder.Eval(e.Row.DataItem, "AchievedPer"));
            }
            
            if(total !=null)
            {
                 string stotal = Convert.ToDecimal(total).ToString();
                 lblTotal.Text =total.ToString();//Error occurs here //'Object reference not set to an instance of an object.'
            
            }
        }
