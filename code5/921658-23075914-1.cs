    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         //check for true/false of datarow column value
         if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "List1.CloumnName")) == "True")
         {
             e.Row.BackColor = System.Drawing.Color.Red;
         }
         else
         {
             e.Row.BackColor = System.Drawing.Color.Green;
         }
    }
