    public ActionResult GetProducts(int id)
    {
        var listOfCourses = db.Courses.ToList();
        
        Task.Delay(9000000);
        
        if (id == 1)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { ErrorMessage = "Test" }, JsonRequestBehavior.AllowGet);
        }
    
        return PartialView("_GetProducts", listOfCourses);
    }
