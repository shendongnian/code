    public IdentityResult ChangePasswordAdmin(string userId, string newPassword) {
         var user = FindById(userId);
         // validate password using PasswordValidator.Validate
         user.PasswordHash = PasswordHasher.HashPassword(newPassword);
         Update(user);
    }
