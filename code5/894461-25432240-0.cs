        [AllowAnonymous]
        public virtual ActionResult NotFound(string message = "")
        {
            HttpContext.Response.StatusCode = 404;
            return View();
        }
