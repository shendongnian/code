    public override void Validate(string userName, string password) {
        string companyID, realUsername;
        string[] parts = userName.Split(':', 2);
        if (parts.Length == 2) {
            companyID = parts[0];
            realUsername = parts[1];
        }
    }
