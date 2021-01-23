    public void verifyUserCredentials(string userName, string password,string message,out int sp_message)
    {
       objRuse = new Reuse();
       objRuse.executeInsertprocedure("ValidateUserCredentials", param, sp_message);
    }
