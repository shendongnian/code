     protected void btnIssueItem_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
                return;
    ....
    }
    protected void tbRoomID_CustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            BAL bal = new BAL();
            args.IsValid = bal.GetRoomByRoomID(Int32.Parse(args.Value)).Count == 0 ? false : true;
        }
