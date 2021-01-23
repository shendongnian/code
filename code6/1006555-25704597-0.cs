       protected void ConfirmButton_Click(object sender, EventArgs e)
    {
    Session["Sales"] = txtSalesPrice.Text;
   
    Session["Amt"] = lblDiscountAmount.Text;
    
    Session["Total"] = lblTotalPrice.Text;
    Response.Redirect("Confirm.aspx");
    }
