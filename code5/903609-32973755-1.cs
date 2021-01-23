        public ActionResult LinkLogin(string provider)
        {
            ControllerContext.HttpContext.Session.RemoveAll();
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }
