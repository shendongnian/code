    [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return PartialView("~/Views/Sahred/_Register.cshtml");
        }
