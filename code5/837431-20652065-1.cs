    string recStatus = Convert.ToString(DataBinder.Eval(e.Row.DataItem,"StatusDesc"));
    if (recStatus == "Approved")
    {
        hlTxnEdit.Enabled = false;
        lnkTxnDelete.Enabled = false;
    }
    else
    {
        hlTxnEdit.Enabled = true;
        lnkTxnDelete.Enabled = true;
        lnkTxnDelete.Attributes.Add("onclick", "return confirm('!!--WARNING--!! You are about to delete the transaction. Performing this action will permanently remove the transaction and all its details from the database. Proceed?')");
    }
