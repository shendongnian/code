    protected void rptrAdmUserList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
       var txtUserName = e.Item.FindControl("txtUserName") as TextBox;
       if (txtUserName != null)
       {
           string pnumber = txtUserName.Text;
           lblseluser.Text = "Selected user is: " + pnumber;
       }
    }
