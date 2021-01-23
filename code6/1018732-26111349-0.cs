    public ActionResult GetCourses([DataSourceRequest] DataSourceRequest request)
    {
        RegistrationService ObjService = new RegistrationService();
        return ObjService.GetCourseDetail().ToDataSourceResult(request);
    }
