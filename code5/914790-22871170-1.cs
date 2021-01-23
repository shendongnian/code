    public override async Task<User> FindAsync(string userName, string password) {
        var identityUser = await base.FindByNameAsync(userName);
        if (identityUser != null) {
            if (userName.EndsWith("@mycompany.net")) {
                var directory = new CompanyDirectory();
                var isValidated = directory.ValidateUser(userName, password);
                if (isValidated) {
                    return identityUser;
                }
            } else {
                //SQL Server Auth
            }
        }
        return null;
    }
