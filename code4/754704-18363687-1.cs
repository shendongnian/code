    public int? GetIsActiveUser(string email)
    {
        System.Data.Objects.ObjectParameter InvitationID;
        InvitationID = new System.Data.Objects.ObjectParameter("InvitationID", -1);
        return this.DataContext.GetIsActiveUser(email, InvitationID);
    }
