        // 
        // POST: /Manage/ChangeAddress
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeAddress(ChangeAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Get the current application user
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    //grab the details
                    user.Address = model.Address;
                    user.City = model.City;
                    user.State = model.State;
                    user.ZipCode = model.ZipCode;
                    // Update the user
                    var result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", new { Message = ManageMessageId.ChangeAddressSuccess });
                    }
                    AddErrors(result);
                    return View(model);
                }
            }
            return View(model);
        }
