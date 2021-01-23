    [HttpPost]
    public ActionResult EditUser(AdminUserEditInput input)
    {
      int id = (int)TempData["UserID"];
      if (ModelState.IsValid)
      {
        _UserService.ChangeMail(id, input.Mail);
        _UserService.ChangeName(id, input.Firstname, input.Name);
        return new RedirectResult(Url.Action("Users", "Admin") + "#id=" + id);
      }
      else
      {
        return new JsonResult { Data = new { Valid = false, Errors = Validator.CheckModelErrors(ModelState) } };
      }
    }
