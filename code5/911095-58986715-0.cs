    public async Task<YourResultModel> ResetPassword(ResetPasswordViewModel vm)
    {
        // Your password validations...
        var user = await _userManager.FindByNameAsync(vm.UserName); 
        // could be FindByEmailAsync if your app uses the user e-mail to login.
        IdentityResult result = await _userManager.ResetPasswordAsync(user, vm.Token, vm.NewPassword);
        return YourResultModelFromIdentityResult(result);
    }
