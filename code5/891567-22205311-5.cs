        IdentityResult result = await UserManager.UpdateAsync(identityUser);
        if (result.Succeeded)
        {
          this.SetNotification("The user has been updated.", EnumToastrNotificationType.Info);
          return RedirectToAction("ShowUsers", "UserManagement");
        }
        else
        {
          this.AddErrors(result);
        }
