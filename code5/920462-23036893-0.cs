    [HttpGet]
    public ActionResult Profile(string username) {
      if (UsersRepository.GetUserByUsername(username) == null) {
        return PartialView("~/Views/Partials/_UsernameNotFound.cshtml", id);
      }
      return View(username);
    }
