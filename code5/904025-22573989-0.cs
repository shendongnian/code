    public JsonResult UpdateTeachers(string models)
    {
    //Deserialize to object
    IList<Teacher> teachers= new JavaScriptSerializer().Deserialize<IList<Teacher>>(models);
    
    return Json(Teacher)
    }
