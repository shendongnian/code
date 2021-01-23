    public async Task<IHttpActionResult> changePassword(UsercredentialsModel usermodel)
    {
      ApplicationUser user = await AppUserManager.FindByIdAsync(usermodel.Id);
      if (user == null)
      {
        return NotFound();
      }
      user.PasswordHash = AppUserManager.PasswordHasher.HashPassword(usermodel.Password);
      var result = await AppUserManager.UpdateAsync(user);
      if (!result.Succeeded)
      {
        //throw exception......
      }
      return Ok();
    }
