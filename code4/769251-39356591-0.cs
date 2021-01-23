    AddUpdateUserVM vm = new AddUpdateUserVM();
    try
    {
        SecurityManager.AddUpdateUserAgent(ua);
    }
    catch (Exception ex)
    {
         //log exception
         vm.HasError = true;
         vm.ErrorMessage = ex.Message;
    }
    return PartialView("AddModifyUserPartialView", vm);
