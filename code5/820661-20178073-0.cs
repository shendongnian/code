    public ActionResult Manage(ManageMessageId? message)
    {
        ViewBag.StatusMessage =
            message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
            : message == ManageMessageId.ChangeDetailsSuccess ? "Your details have been changed."
            : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
            : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
            : message == ManageMessageId.Error ? "An error has occurred."
            : "";
        ViewBag.HasLocalPassword = HasPassword();
        ViewBag.ReturnUrl = Url.Action("Manage");
        // Get the currently logged on user
        var user = UserManager.FindById(User.Identity.GetUserId());
        // Copy the value of FullName to the view model
        var vm = new ManageUserViewModel {
            FullName = user.FullName
        };
        return View(vm);
    }
