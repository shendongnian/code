    [HttpGet]
    public ActionResult EditRole(int? selectedRoleId)
    {
        AddEditRoleViewModel role = _userService.GetAllRoles(selectedRoleId);
        return View(role);
    }
    [HttpPost]
    public ActionResult EditRoleSave(AddEditRoleViewModel role)
    {
        _userService.SaveRole(role);
        return RedirectToAction("EditRole", new { selectedRoleId = role.Id });
    }
