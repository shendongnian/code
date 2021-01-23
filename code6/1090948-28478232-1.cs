    public JsonResult DepartmentNameExists(string name, int id = 0)
    {
        return !(db.Departments.Any(x => x.Name == name.Trim() && x.Id != id) 
                  ? Json(true, JsonRequestBehavior.AllowGet) 
                  : Json(string.Format("{0} already exists.", name), 
                                            JsonRequestBehavior.AllowGet);
    }
