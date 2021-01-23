        [HttpGet]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider) {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback"));
        }
