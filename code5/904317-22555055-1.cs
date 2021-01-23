    //Decimal to String in lable.text control//   
    protected void gvProd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         decimal total = 0;
         decimal profit = 0;
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
             object objAchievedPer = DataBinder.Eval(e.Row.DataItem, "AchievedPer");             
             Label lblTotal = (Label)e.Row.FindControl("lbltotal");
            if(lblTotal != null)
            {
                  if(objAchievedPer != null)
                  {
                        total = Convert.ToDecimal(objAchievedPer);
                  }
	          lblTotal.Text = total.ToString();
            }          
         }
    }
