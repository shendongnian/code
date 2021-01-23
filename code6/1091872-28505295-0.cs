    [AllowAnonymous]
    public async Task<JsonResult> UserAlreadyExistsAsync(string email)
    {
        var result = 
            await userManager.FindByNameAsync(email) ?? 
            await userManager.FindByEmailAsync(email);
        return Json(result == null, JsonRequestBehavior.AllowGet);
    }
