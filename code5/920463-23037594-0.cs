    public ActionResult Profile(string id) {
    if (UsersRepository.GetUserByUsername(id) == null) {
        return PartialView("~/Views/Partials/_UsernameNotFound.cshtml", id);
    }
    ViewBag.Username=id;
    return View();
    }
