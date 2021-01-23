    [HttpPost]
    public ActionResult Login(LoginModel model, string post)
    {
        Repo.Resolve<ILogsRepository>().LogLoginAttempt(model.Username, this.Request.UserHostAddress, this.Request.RawUrl);
        if (ModelState.IsValid) {
            var login = this._authRepository.ValidateCredentials(model.Username, model.Password);
            if (login != null) {
                Task.Run(() => Logger.Log(Action.UserSignIn, Level.Log, string.Format("User signed in as '{0}' -> '{1}'", model.Username, login)));
                return Request.IsAjaxRequest() ? Content("__close__") : ClientCabinet();
            }
           Task.Run(() => Logger.Log(Action.UserSignIn, Level.Mandatory, Event.Error, string.Format("User failed to sign in as '{0}': invalid username or password", model.Username)));
            ModelState.AddModelError("Username", @"login or password is incorrect!");
        }
        return View(model);
    }
