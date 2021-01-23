    public ActionResult Confirm(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return HandleMissingId();
        }
        int parsedId;
        if (!int.TryParse(id, out parsedId))
        {
            return Http(400, View("BadRequest", model: "EC2007: Could not parse int"));
        }
        return Try(() =>
        {
            ConfirmUser(parseId);
            return RedirectToAction("Index");
        }, ShowGenericError);
    }
    
    private void ConfirmUser(int userId)
    {
        UserBusinessLogic.ConfirmUser(userId);
        _authentication.SetAuthCookie(userId.ToString(CultureInfo.InvariantCulture), true);
    }
    
    private ShowGenericError(int code, int errorCode)
    {
        return Http(code, GenericErrorView(null, null, errorCode));
    }
    
    private ActionResult HandleMissingId()
    {
        if (! IsLoggedIn())
        {
            return RedirectToAction("Login");
        }
        if(User.User.Confirmed)
        {
            return RedirectToAction("Index");
        }
        return View("PendingConfirmation");
    }
