    // in the CreateUser method,
    // call separated logic
    var viewModel = await GetRegisterAdditionalDetailsViewModelAsync(user.Id);
    // and then return a view with specific viewName and model.
    return View("RegisterAdditionalDetails", viewModel);
