    [HttpPost, ValidateAntiForgeryToken]
    public async Task<ActionResult> Claims_UpdateByClaimGroup([Bind(Include = "Id,SelectedClaimGroupId")] UserClaimsViewModel viewModel)
    {
        var claimGroup = await _repository.GetAsync<ClaimGroup>(Convert.ToInt32(viewModel.SelectedClaimGroupId));
        User user = await _repository.GetAsync<User>(viewModel.Id);
        ApplicationUser appUser = await UserManager.FindByIdAsync(user.AppUser.Id);
        // Remove all the old claims
        var listToRemove = appUser.Claims.ToArray();
        foreach (var item in listToRemove)
        {
            await UserManager.RemoveClaimAsync(item.UserId, new Claim(item.ClaimType, item.ClaimValue));
        }
        try
        {
            // Then add the new claims.
            foreach (ClaimGroupItems claimGroupItem in claimGroup.Items)
            {
                //UserManager.AddClaim(appUser.Id, new Claim(claimGroupItem.MenuItemId.ToString(), claimGroupItem.ClaimValue));
                appUser.Claims.Add(new IdentityUserClaim()
                {
                    UserId = appUser.Id,
                    ClaimType = claimGroupItem.MenuItemId.ToString(),
                    ClaimValue = claimGroupItem.ClaimValue,
                });
            }
            await UserManager.UpdateAsync(appUser);
        }
        catch (DbEntityValidationException dbEx)
        {
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                        validationErrors.Entry.Entity.GetType().FullName,
                        validationError.PropertyName,
                        validationError.ErrorMessage);
                }
            }
            throw;  // You can also choose to handle the exception here...
        }
        return RedirectToAction("Claims", new { id = viewModel.Id, Updated = true });
    }
