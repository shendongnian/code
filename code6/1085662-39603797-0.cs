    protected void gvListInventoryPassword_RowDataBound(object sender, GridViewRowEventArgs e)
    {    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {         
            HtmlButton buttonPass= (HtmlButton)e.Row.FindControl("buttonPass");
            TextBox txtBox= (TextBox)e.Row.FindControl("txtBox");
            btnBluPass.Attributes.Add("data-clipboard-target", "#" + txtBox.ClientID);
        }
    }//End of gvListInventoryPassword_RowDataBound function
