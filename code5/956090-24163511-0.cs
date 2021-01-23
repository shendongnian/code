    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
      {
        Button btnEdit = e.Row.FindControl("btnEdit") as Button;
        if(lblUser.Text !="Admin")
          btnEdit.OnClientClick = "alert('Not allowed');return false;";
      }
    }
