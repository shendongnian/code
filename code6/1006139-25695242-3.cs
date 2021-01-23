    protected void MessageDataSrc_Updating(object sender, SqlDataSourceCommandEventArgs e)
    {
        e.Command.Parameters["@CoID"].Value = clsCompany.GetCompanyNumber();
        e.Command.Parameters["@Sender"].Value = clsUser.LoggedInUserName();
        e.Command.Parameters["@TStamp"].Value = DateTime.UtcNow; // Appears to be missing
    }
