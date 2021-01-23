        [AllowAnonymous]
        [CallbackAction]
        public ActionResult SendExpirationMessage(int userId)
        {
            // TODO Lookup the user's information and send the trial expiration message
            // ...
            return new EmptyResult();
        }
