    if (this.PasswordLookup1Status.AskExt(true) == WebDialogResult.OK)
    {
        string currentPassword = this.PasswordLookup1Filter.Current.Pwd;
        this.PasswordLookup1Filter.Current.Pwd = "";
        this.PasswordLookup1Filter.Update(this.PasswordLookup1Filter.Current);
        if (currentPassword  == "1234")
        {
            Base.Transactions.Ask("Information", "Password [" + currentPassword  + "] is correct.", MessageButtons.OK);
            Base.Transactions.ClearDialog();
        }
        else
        {
            throw new PXException("Password [" + currentPassword  + "] is incorrect.");
        }
        this.PasswordLookup1Filter.ClearDialog();
    }
