    public JsonResult DepartmentNameExists(string name, int id = 0)
    {
        var user = db.Departments.Where(x => x.Name == name.Trim() && x.Id != id);
        return !user.Any() ?
          Json(true, JsonRequestBehavior.AllowGet) :
          Json(string.Format("{0} already exists.", name),
              JsonRequestBehavior.AllowGet);
    }
