    public JsonResult DepartmentNameExists(string name, int id = 0)
    {
        return db.Departments.Any(x => x.Name == name.Trim() && x.Id != id) 
                  ? Json(string.Format("{0} already exists.", name), 
                                            JsonRequestBehavior.AllowGet)
                  : Json(true, JsonRequestBehavior.AllowGet);
    }
