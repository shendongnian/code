    [HttpPost]
    public ActionResult ProcessCourseApplicationURL(CourseApplicationsURLFeed_Model obj)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                  _effectedCourseInstances = _coursesServices.ProcessAllCoursesApplicationURL(obj);
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Unable To Process Courses Application URL from CID DB" + ex);
            }
            return PartialView("CourseApplicationURLTest_Partial", _effectedCourseInstances); 
        }
