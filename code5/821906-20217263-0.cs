    public ActionResult _LoginPartial(LoginModel login)
    {
        // also a good idea to check `ModelState.IsValid`
        if (ModelState.IsValid)
        {
            // Go ahead and log them in if everything checks out, then return
            // your successful response
            return Json(new { status = 200, msg = "OK" });
        }
        // Erroneous response
        return Json(new { status = 401, msg = "Unauthorized" });
    }
